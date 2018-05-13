namespace Ek.Shop.Domain.Orders
{
    public class OrderCharacteristicTranslation : CharacteristicTranslation
    {
        public OrderCharacteristicTranslation()
        { }

        public OrderCharacteristic Characteristic { get; set; }

        public int CharacteristicId { get; set; }
    }
}
