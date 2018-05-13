namespace Ek.Shop.Contracts.Commands
{
    public class DeleteBasketItemCommand : ICommand
    {
        public DeleteBasketItemCommand()
        { }

        public DeleteBasketItemCommand(int basketItemId)
        {
            BasketItemId = basketItemId;
        }

        public int BasketItemId { get; set; }
    }
}
