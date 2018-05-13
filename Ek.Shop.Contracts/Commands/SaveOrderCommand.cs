using Ek.Shop.Application.Orders;

namespace Ek.Shop.Contracts.Commands
{
    public class SaveOrderCommand : ICommand
    {
        public SaveOrderCommand()
        { }

        public OrderDto Order { get; set; }

        public string RouteUrl { get; set; }
    }
}
