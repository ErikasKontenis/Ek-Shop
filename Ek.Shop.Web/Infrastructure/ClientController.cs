namespace Ek.Shop.Web.Infrastructure
{
    public class ClientController : ApiControllerAsync
    {
        public ClientController(IBus bus)
            : base(bus)
        { }
    }
}
