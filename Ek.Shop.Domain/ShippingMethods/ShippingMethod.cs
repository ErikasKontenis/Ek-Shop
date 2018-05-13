using Ek.Shop.Domain.Orders;
using System.Collections.Generic;

namespace Ek.Shop.Domain.Transactions
{
    public class ShippingMethod : Classifier
    {
        public ShippingMethod()
        {
            Orders = new HashSet<Order>();
        }

        public decimal Price { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
