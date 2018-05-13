using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;
using Microsoft.AspNetCore.SpaServices.Prerendering;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AspCoreServer.Controllers
{
    public class ClientController : Controller
    {
        public ClientController()
        { }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Workaround of angular5 file-upload unhandable url request
            if (Request.Path.ToString().StartsWith("/null"))
            {
                return View();
            }

            var prerenderResult = await Request.BuildPrerender();
            ViewData["SpaHtml"] = prerenderResult.Html; // <app> from Angular
            ViewData["Title"] = prerenderResult.Globals["title"]; // set <title> from Angular
            ViewData["Styles"] = prerenderResult.Globals["styles"]; // put styles in the correct place
            ViewData["Scripts"] = prerenderResult.Globals["scripts"]; // scripts (that were in header)
            ViewData["Meta"] = prerenderResult.Globals["meta"]; // set <meta> SEO tags
            ViewData["Links"] = prerenderResult.Globals["links"]; // set <link rel="canonical"> etc SEO tags
            ViewData["TransferData"] = prerenderResult.Globals["transferData"]; // transfer data set to window.TRANSFER_CACHE = {};
            var statusCode = prerenderResult.GetStatusCodeFromMeta();
            if (statusCode.HasValue)
            {
                HttpContext.Response.StatusCode = statusCode.Value;
            }

            return View();
        }

        [HttpGet]
        [Route("sitemap.xml")]
        public IActionResult SitemapXml()
        {
            var xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";

            xml += "<sitemapindex xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">";
            xml += "<sitemap>";
            xml += "<loc>http://localhost:4251/home</loc>";
            xml += "<lastmod>" + DateTime.Now.ToString("yyyy-MM-dd") + "</lastmod>";
            xml += "</sitemap>";
            xml += "<sitemap>";
            xml += "<loc>http://localhost:4251/counter</loc>";
            xml += "<lastmod>" + DateTime.Now.ToString("yyyy-MM-dd") + "</lastmod>";
            xml += "</sitemap>";
            xml += "</sitemapindex>";

            return Content(xml, "text/xml");
        }

        public IActionResult Error()
        {
            return View();
        }
    }

    public class IRequest
    {
        public object cookies { get; set; }

        public object headers { get; set; }

        public object host { get; set; }
    }

    public class TransferData
    {
        public dynamic request { get; set; }
        
        public object thisCameFromDotNET { get; set; }
    }

    public static class HttpRequestExtensions
    {
        public static int? GetStatusCodeFromMeta(this RenderToStringResult renderToStringResult)
        {
            // --- Parse the meta description
            var meta = renderToStringResult.Globals.Descendants().FirstOrDefault(o => o.Path == "meta").First.ToString();
            var statusCodeMatch = Regex.Match(meta, "property=\"statusCode\" content\\s*=\\s*(?:\"(?<1>[^\"]*)\"|(?<1>\\S+))");
            var statusCode = statusCodeMatch.Groups[1].Value;
            if (string.IsNullOrEmpty(statusCode))
            {
                return null;
            }

            return Convert.ToInt32(statusCodeMatch.Groups[1].Value);
        }

        public static IRequest AbstractRequestInfo(this HttpRequest request)
        {
            IRequest requestSimplified = new IRequest();
            requestSimplified.cookies = request.Cookies;
            requestSimplified.headers = request.Headers;
            requestSimplified.host = request.Host;

            return requestSimplified;
        }

        public static async Task<RenderToStringResult> BuildPrerender(this HttpRequest request)
        {
            var nodeServices = request.HttpContext.RequestServices.GetRequiredService<INodeServices>();
            var hostEnv = request.HttpContext.RequestServices.GetRequiredService<IHostingEnvironment>();
            var applicationBasePath = hostEnv.ContentRootPath;
            var requestFeature = request.HttpContext.Features.Get<IHttpRequestFeature>();
            var unencodedPathAndQuery = requestFeature.RawTarget;
            var unencodedAbsoluteUrl = $"{request.Scheme}://{request.Host}{unencodedPathAndQuery}";

            var transferData = new TransferData();
            transferData.request = request.AbstractRequestInfo();
            transferData.thisCameFromDotNET = "Hi Angular it's asp.net :)";

            CancellationTokenSource cancelSource = new CancellationTokenSource();
            CancellationToken cancelToken = cancelSource.Token;

            return await Prerenderer.RenderToString(
                "/",
                nodeServices,
                cancelToken,
                new JavaScriptModuleExport(applicationBasePath + "/App/dist/client-app-server"),
                unencodedAbsoluteUrl,
                unencodedPathAndQuery,
                transferData, // the simplified Request object & any other CustomData
                30000,
                request.PathBase.ToString()
            );
        }
    }
}
