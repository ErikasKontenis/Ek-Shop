using CacheManager.Core;
using Ek.Shop.Application.Services.Authentications;
using Ek.Shop.Base.Application.Services.QueryHandlers.ClassifierQueryHandler;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.Caches;
using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Queries.Queries;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Base.Data.WorkContexts;
using Ek.Shop.Data.Baskets;
using Ek.Shop.Data.Categories;
using Ek.Shop.Data.ClassifierStores;
using Ek.Shop.Domain.Users;
using Ek.Shop.Web.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AspCoreServer
{
    public class Startup
    {
        private readonly Container container = new Container();

        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseSetting("detailedErrors", "true") // Delete in production
                .CaptureStartupErrors(true) // Delete in production
                .Build();
            
            host.Run();
        }

        public Startup(IHostingEnvironment env)
        {
            var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddJsonFile("cache.json", optional: false)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IntegrateSimpleInjector(services);

            services.AddDbContext<EkShopContext>();
            services.AddIdentity<User, Ek.Shop.Domain.Identities.IdentityRole>(options =>
            {
                // Workaround: Ignore all default identityOptions since they are configurable in field characteristics.
                options.Password.RequiredLength = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<EkShopContext>()
            .AddDefaultTokenProviders();

            services.AddSession(options =>
            {
                options.Cookie.Name = "EkShopSession";
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            services.AddCacheManagerConfiguration(Configuration);
            services.AddCacheManager<object>(inline => inline.WithDictionaryHandle().WithExpiration(ExpirationMode.Absolute, TimeSpan.FromMinutes(15)));

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "EkShopIdentity";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(60);
                options.LoginPath = "";
                options.LogoutPath = "";
                options.AccessDeniedPath = "";
                options.SlidingExpiration = true;
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.Events = new CookieAuthenticationEvents
                {
                    OnRedirectToLogin = ctx =>
                    {
                        if (ctx.Request.Path.StartsWithSegments("/api") &&
                            ctx.Response.StatusCode == (int)HttpStatusCode.OK)
                        {
                            ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        }
                        else if (ctx.Response.StatusCode == (int)HttpStatusCode.Forbidden)
                        {
                            ctx.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                        }

                        return Task.CompletedTask;
                    }
                };
            });

            // Add framework services.
            services.AddMvc(options =>
            {
                options.CacheProfiles.Add("ResponseCachingDefault",
                new CacheProfile()
                {
                    Duration = Debugger.IsAttached ? 0 : 60 * 60 
                });
                options.CacheProfiles.Add("ResponseCachingNever",
                new CacheProfile()
                {
                    Location = ResponseCacheLocation.None,
                    NoStore = true
                });
            })
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddResponseCaching();
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                {
                    "image/svg+xml",
                    "image/png",
                    "image/jpg",
                    "image/jpeg",
                    "image/gif"
                });
            });
            services.AddNodeServices();
            
            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
              c.SwaggerDoc("v1", new Info { Title = "EkShop", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            InitializeContainer(app);

            app.UseAuthentication();
            app.UseSession();
            app.Use((c, n) => container.GetInstance<WorkContextMiddleware>().Invoke(c, n));

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // Delete in final production
            app.UseDeveloperExceptionPage();
            if (env.IsProduction())
            {
                app.UseResponseCompression();
                app.UseStaticFiles(new StaticFileOptions
                {
                    OnPrepareResponse = ctx =>
                    {
                        const int durationInSeconds = 60 * 60 * 24 * 30;
                        ctx.Context.Response.Headers[HeaderNames.CacheControl] =
                            "public,max-age=" + durationInSeconds;
                    }
                });
            }
            
            if (env.IsDevelopment())
            {
                app.UseStaticFiles();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                    HotModuleReplacementEndpoint = "/dist/"
                });
            }

            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.MapWhen(x => !x.Request.Path.Value.StartsWith("/swagger", StringComparison.OrdinalIgnoreCase) && !x.Request.Path.Value.StartsWith("/admin", StringComparison.OrdinalIgnoreCase), builder =>
            {
                builder.UseMvc(routes =>
                {
                    routes.MapSpaFallbackRoute(
                      name: "client-app-fallback",
                      defaults: new { controller = "Client", action = "Index" });
                });
            });

            app.MapWhen(x => x.Request.Path.Value.StartsWith("/admin", StringComparison.OrdinalIgnoreCase), builder =>
            {
                builder.UseMvc(routes =>
                {
                    routes.MapSpaFallbackRoute(
                      name: "admin-app-fallback",
                      defaults: new { controller = "Admin", action = "Index" });
                });
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "default",
                  template: "{controller=Client}/{action=Index}/{id?}");

                routes.MapRoute(
                  "Sitemap",
                  "sitemap.xml",
                  new { controller = "Client", action = "SitemapXml" });

                routes.MapSpaFallbackRoute(
                  name: "client-app-fallback",
                  defaults: new { controller = "Client", action = "Index" });

                routes.MapSpaFallbackRoute(
                  name: "admin-app-fallback",
                  templatePrefix: "admin",
                  defaults: new { controller = "Admin", action = "Index" });
            });
        }

        private void IntegrateSimpleInjector(IServiceCollection services)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(
                new SimpleInjectorControllerActivator(container));
            services.AddSingleton<IViewComponentActivator>(
                new SimpleInjectorViewComponentActivator(container));

            services.EnableSimpleInjectorCrossWiring(container);
            services.UseSimpleInjectorAspNetRequestScoping(container);
        }

        private void InitializeContainer(IApplicationBuilder app)
        {
            // Add application presentation components:
            container.RegisterMvcControllers(app);
            container.RegisterMvcViewComponents(app);

            // Add application services:
            container.Register<IBus, Bus>();
            container.Register(typeof(IClassifierBus<,>), typeof(ClassifierBus<,>));
            container.Register<IWorkContext, WorkContext>();
            container.Register<ICache, Cache>();
            container.Register<IClassifierStoresRepository, ClassifierStoresRepository>();
            container.Register<IQueryProcessor, QueryProcessor>(Lifestyle.Scoped);

            container.Register(typeof(IQueryHandler<,>), new[] { typeof(AuthenticateUserQueryHandler).Assembly });
            container.Register(typeof(IRemoteQuery<,>), new[] { typeof(AddProductToBasketQuery).Assembly });
            container.Register(typeof(IQuery<,>), new[] { typeof(GetCategoryBaseQuery).Assembly });

            // TODO: Temporary do not cache any queries because of lost EF model reference and impossibility to track decorated query model-result. 
            container.RegisterDecorator(typeof(IRemoteQuery<,>),
                typeof(RemoteQueryCacheDecorator<,>));

            // TODO: Refactor to use simpleInjector UseMiddleware
            container.Register<WorkContextMiddleware>();

            container.AutoCrossWireAspNetComponents(app);
            container.Verify();
        }
    }
}
