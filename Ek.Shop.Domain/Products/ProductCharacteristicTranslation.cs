namespace Ek.Shop.Domain.Products
{
    public class ProductCharacteristicTranslation : CharacteristicTranslation
    {
        public ProductCharacteristicTranslation()
        { }

        public ProductCharacteristic Characteristic { get; set; }

        public int CharacteristicId { get; set; }
    }
}
