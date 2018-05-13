using Ek.Shop.Web.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ek.Shop.Web.ControllersApi.Admin
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class DashboardAdminController : AdminController
    {
        public DashboardAdminController(IBus bus)
            : base(bus)
        { }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetDashboard()
        {
            await Task.FromResult(true);

            return Ok(true);
        }
    }
}
