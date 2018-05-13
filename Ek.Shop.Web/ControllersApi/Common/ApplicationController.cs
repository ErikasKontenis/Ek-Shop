using Ek.Shop.Application.Routes;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Enums;
using Ek.Shop.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Web.ControllersApi.Common
{
    [ResponseCache(CacheProfileName = "ResponseCachingDefault")]
    [Route("api/[controller]")]
    public class ApplicationController : ApiControllerAsync
    {
        public ApplicationController(IBus bus)
            : base(bus)
        { }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetResources(string url)
        {
            url = url?.TrimStart('/') ?? "";

            var routesDtoResult = await QueryProcessor.GetQueryHandler<ListRoutesCommand, List<RouteDto>>(new ListRoutesCommand());
            if (routesDtoResult.Failure)
            {
                return BadRequest(routesDtoResult.ErrorMessages);
            }

            var routesDto = routesDtoResult.Object;
            var resourcesDictionary = new Dictionary<string, object>();

            addAdminResources();
            addClientResources();

            void addAdminResources()
            {
                if (WorkContext.WorkingInputFormName == InputFormCodes.Admin)
                {
                    var adminLoginRouteDto = routesDto.FirstOrDefault(o => o.AngularComponent == AngularComponents.LoginComponent && o.InputForm == InputFormCodes.Admin);
                    resourcesDictionary.Add("loginPath", adminLoginRouteDto.Url);
                    var adminDashboardRouteDto = routesDto.FirstOrDefault(o => o.AngularComponent == AngularComponents.DashboardAdminComponent && o.InputForm == InputFormCodes.Admin);
                    resourcesDictionary.Add("loginRedirect", adminDashboardRouteDto.Url);
                }
            }

            void addClientResources()
            {
                if (WorkContext.WorkingInputFormName != InputFormCodes.Admin)
                {
                    var clientLoginRouteDto = routesDto.FirstOrDefault(o => o.AngularComponent == AngularComponents.LoginComponent && o.InputForm != InputFormCodes.Admin);
                    resourcesDictionary.Add("loginPath", clientLoginRouteDto.Url);
                    var clientHomeRouteDto = routesDto.FirstOrDefault(o => o.AngularComponent == AngularComponents.ProfileComponent && o.InputForm != InputFormCodes.Admin);
                    resourcesDictionary.Add("loginRedirect", clientHomeRouteDto.Url);
                }
            }

            return Ok(resourcesDictionary);
        }
    }
}
