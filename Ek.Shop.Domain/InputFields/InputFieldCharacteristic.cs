namespace Ek.Shop.Domain.InputFields
{
    public class InputFieldCharacteristic : CharacteristicBase<InputFieldCharacteristicTranslation>
    {
        public InputFieldCharacteristic()
            : base()
        { }

        public InputField InputField { get; set; }

        public int InputFieldId { get; set; }
    }
}
