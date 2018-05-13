namespace Ek.Shop.Domain.Products
{
    /// <summary>
    /// Not implemented yet
    /// </summary>
    public class ProductSpecificationAttribute : Classifier
    {
        public ProductSpecificationAttribute()
        { }

        public Product Product { get; set; }

        public int ProductId { get; set; }

        public ProductSpecificationAttributeOption ProductSpecificationAttributeOption { get; set; }

        public int ProductSpecificationAttributeOptionId { get; set; }
    }
}
