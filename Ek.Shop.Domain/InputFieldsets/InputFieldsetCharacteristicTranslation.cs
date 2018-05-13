namespace Ek.Shop.Domain.InputFieldsets
{
    public class InputFieldsetCharacteristicTranslation : CharacteristicTranslation
    {
        public InputFieldsetCharacteristicTranslation()
        { }

        public InputFieldsetCharacteristic Characteristic { get; set; }

        public int CharacteristicId { get; set; }
    }
}
