using Ek.Shop.Application.Classifiers;
using System.Collections.Generic;

namespace Ek.Shop.Application.Orders
{
    public class OrderDataDto
    {
        public List<PaymentMethodDto> PaymentMethods { get; set; }

        public List<ShippingMethodDto> ShippingMethods { get; set; }

        public decimal TotalBasketPrice { get; set; }

        public decimal TotalBasketVat { get; set; }
    }
}
