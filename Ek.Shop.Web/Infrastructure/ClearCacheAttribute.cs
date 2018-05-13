using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Web.Infrastructure
{
    public class ClearCacheAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            var gg = 123;
            var lol = actionContext.HttpContext.RequestServices.GetService(typeof(IMemoryCache));
        }
    }
}
