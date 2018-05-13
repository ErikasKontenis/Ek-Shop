namespace Ek.Shop.Domain.Images
{
    public class ImageCharacteristic : CharacteristicBase<ImageCharacteristicTranslation>
    {
        public ImageCharacteristic()
            : base()
        { }

        public Image Image { get; set; }

        public int ImageId { get; set; }
    }
}
