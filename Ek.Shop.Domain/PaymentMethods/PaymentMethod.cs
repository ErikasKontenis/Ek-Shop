using Ek.Shop.Domain.Orders;
using System.Collections.Generic;

namespace Ek.Shop.Domain.PaymentMethods
{
    public class PaymentMethod : Classifier
    {
        public PaymentMethod()
        {
            PaymentMethodTypes = new HashSet<PaymentMethodType>();
            Orders = new HashSet<Order>();
        }

        public ICollection<PaymentMethodType> PaymentMethodTypes { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
