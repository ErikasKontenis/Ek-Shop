using Ek.Shop.Domain.Baskets;
using System.Collections.Generic;

namespace Ek.Shop.Domain.Products
{
    public class ProductDetail : Entity
    {
        public ProductDetail()
        {
            BasketItems = new HashSet<BasketItem>();
            Characteristics = new HashSet<ProductDetailCharacteristic>();
        }

        public virtual ICollection<BasketItem> BasketItems { get; set; }

        public string Value { get; set; }

        public bool IsOutOfStock { get; set; }

        public virtual Product Product { get; set; }

        public int ProductId { get; set; }

        public ICollection<ProductDetailCharacteristic> Characteristics { get; set; }

        public virtual ProductDetailType ProductDetailType { get; set; }

        public int ProductDetailTypeId { get; set; }
    }
}
