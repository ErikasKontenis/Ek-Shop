namespace Ek.Shop.Domain.Categories
{
    public class CategoryCharacteristicTranslation : CharacteristicTranslation
    {
        public CategoryCharacteristicTranslation()
        { }

        public CategoryCharacteristic Characteristic { get; set; }

        public int CharacteristicId { get; set; }
    }
}
