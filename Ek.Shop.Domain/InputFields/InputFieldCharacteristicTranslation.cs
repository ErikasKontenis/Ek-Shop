namespace Ek.Shop.Domain.InputFields
{
    public class InputFieldCharacteristicTranslation : CharacteristicTranslation
    {
        public InputFieldCharacteristicTranslation()
        { }

        public InputFieldCharacteristic Characteristic { get; set; }

        public int CharacteristicId { get; set; }
    }
}
