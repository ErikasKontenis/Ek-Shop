using System.Collections.Generic;

namespace Ek.Shop.Domain.Orders
{
    public class OrderStatus : Classifier
    {
        public OrderStatus()
        {
            Orders = new HashSet<Order>();
        }

        public ICollection<Order> Orders { get; set; }
    }
}
