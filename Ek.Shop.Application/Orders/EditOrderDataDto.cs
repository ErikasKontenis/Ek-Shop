using Ek.Shop.Application.Classifiers;
using System.Collections.Generic;

namespace Ek.Shop.Application.Orders
{
    public class EditOrderDataDto
    {
        public OrderDto Order { get; set; }

        public List<OrderStatusDto> OrderStatuses { get; set; }

        public List<PaymentMethodDto> PaymentMethods { get; set; }

        public List<ShippingMethodDto> ShippingMethods { get; set; }
    }
}
