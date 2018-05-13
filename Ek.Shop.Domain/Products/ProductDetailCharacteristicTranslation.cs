namespace Ek.Shop.Domain.Products
{
    public class ProductDetailCharacteristicTranslation : CharacteristicTranslation
    {
        public ProductDetailCharacteristicTranslation()
        { }

        public ProductDetailCharacteristic Characteristic { get; set; }

        public int CharacteristicId { get; set; }
    }
}
