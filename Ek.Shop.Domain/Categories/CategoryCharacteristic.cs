namespace Ek.Shop.Domain.Categories
{
    public class CategoryCharacteristic : CharacteristicBase<CategoryCharacteristicTranslation>
    {
        public CategoryCharacteristic()
            : base()
        { }

        public Category Category { get; set; }

        public int CategoryId { get; set; }
    }
}
