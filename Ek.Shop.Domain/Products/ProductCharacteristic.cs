namespace Ek.Shop.Domain.Products
{
    public class ProductCharacteristic : CharacteristicBase<ProductCharacteristicTranslation>
    {
        public ProductCharacteristic()
            : base()
        { }

        public Product Product { get; set; }

        public int ProductId { get; set; }
    }
}
