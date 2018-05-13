using Microsoft.AspNetCore.Mvc;

namespace Ek.Shop.Web.Controllers
{
    public class AdminController : Controller
    {
        public AdminController()
        { }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
