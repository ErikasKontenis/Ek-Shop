namespace Ek.Shop.Domain.Products
{
    public class ProductDetailCharacteristic : CharacteristicBase<ProductDetailCharacteristicTranslation>
    {
        public ProductDetailCharacteristic()
            : base()
        { }

        public ProductDetail ProductDetail { get; set; }

        public int ProductDetailId { get; set; }
    }
}
