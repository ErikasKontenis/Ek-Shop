using System.Collections.Generic;

namespace Ek.Shop.Domain.Products
{
    public class ProductSpecificationAttributeOption : Classifier
    {
        public ProductSpecificationAttributeOption()
        {
            ProductSpecificationAttributes = new HashSet<ProductSpecificationAttribute>();
        }

        public ICollection<ProductSpecificationAttribute> ProductSpecificationAttributes { get; set; }
    }
}
