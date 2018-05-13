using System.Collections.Generic;

namespace Ek.Shop.Domain.Products
{
    public class ProductDetailType : Classifier
    {
        public ProductDetailType()
        {
            ProductDetails = new HashSet<ProductDetail>();
        }

        public ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
