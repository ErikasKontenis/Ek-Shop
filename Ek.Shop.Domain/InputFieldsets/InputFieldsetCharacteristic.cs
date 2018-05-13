namespace Ek.Shop.Domain.InputFieldsets
{
    public class InputFieldsetCharacteristic : CharacteristicBase<InputFieldsetCharacteristicTranslation>
    {
        public InputFieldsetCharacteristic()
            : base()
        { }

        public InputFieldset InputFieldset { get; set; }

        public int InputFieldsetId { get; set; }
    }
}
