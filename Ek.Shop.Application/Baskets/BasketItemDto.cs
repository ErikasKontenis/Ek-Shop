using Ek.Shop.Application.Products;

namespace Ek.Shop.Application.Baskets
{
    public class BasketItemDto
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public ProductDto Product { get; set; }

        public int? ProductDetailId { get; set; }

        public int Quantity { get; set; }

        public decimal GetTotalPrice()
        {
            return Price * Quantity;
        }
    }
}
