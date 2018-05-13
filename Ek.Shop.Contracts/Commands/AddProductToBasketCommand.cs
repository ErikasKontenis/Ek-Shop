namespace Ek.Shop.Contracts.Commands
{
    public class AddProductToBasketCommand : ICommand
    {
        public AddProductToBasketCommand()
        { }

        public AddProductToBasketCommand(int productId, int quantity, int? productDetailId = null)
        {
            ProductDetailId = productDetailId;
            ProductId = productId;
            Quantity = quantity;
        }

        public int? ProductDetailId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
