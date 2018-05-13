using Ek.Shop.Domain.Products;

namespace Ek.Shop.Domain.Baskets
{
    public class BasketItem : Entity
    {
        public BasketItem()
        { }

        public Basket Basket { get; set; }

        public int BasketId { get; set; }

        public decimal Price { get; set; }

        public ProductDetail ProductDetail { get; set; }

        public int? ProductDetailId { get; set; }

        public Product Product { get; set; }

        public int? ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal GetTotalPrice()
        {
            return Price * Quantity;
        }
    }
}
