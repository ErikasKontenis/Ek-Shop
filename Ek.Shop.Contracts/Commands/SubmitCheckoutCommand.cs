using Ek.Shop.Application.Orders;

namespace Ek.Shop.Contracts.Commands
{
    public class SubmitOrderCommand : ICommand
    {
        public SubmitOrderCommand()
        { }

        public SubmitOrderCommand(OrderDto order, string routeUrl)
        {
            Order = order;
            RouteUrl = routeUrl;
        }

        public OrderDto Order { get; set; }

        public string RouteUrl { get; set; }
    }
}
