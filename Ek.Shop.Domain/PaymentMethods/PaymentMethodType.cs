using Ek.Shop.Domain.Orders;
using System.Collections.Generic;

namespace Ek.Shop.Domain.PaymentMethods
{
    public class PaymentMethodType : Classifier
    {
        public PaymentMethodType()
        {
            Orders = new HashSet<Order>();
        }

        public PaymentMethod PaymentMethod { get; set; }

        public int PaymentMethodId { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
