namespace Ek.Shop.Domain.Orders
{
    public class OrderCharacteristic : CharacteristicBase<OrderCharacteristicTranslation>
    {
        public OrderCharacteristic()
            : base ()
        { }

        public Order Order { get; set; }

        public int OrderId { get; set; }
    }
}
