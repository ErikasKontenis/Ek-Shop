namespace Ek.Shop.Web.Infrastructure
{
    public class AdminController : ApiControllerAsync
    {
        public AdminController(IBus bus)
            : base(bus)
        { }
    }
}
