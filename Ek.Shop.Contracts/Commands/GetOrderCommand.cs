namespace Ek.Shop.Contracts.Commands
{
    public class GetOrderCommand : ICommand
    {
        public GetOrderCommand()
        { }

        public GetOrderCommand(int? orderId)
        {
            OrderId = orderId;
        }

        public int? OrderId { get; set; }
    }
}
