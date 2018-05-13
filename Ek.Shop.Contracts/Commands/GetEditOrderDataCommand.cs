namespace Ek.Shop.Contracts.Commands
{
    public class GetEditOrderDataCommand : ICommand
    {
        public GetEditOrderDataCommand()
        { }

        public GetEditOrderDataCommand(int? orderId)
        {
            OrderId = orderId;
        }

        public int? OrderId { get; set; }
    }
}
