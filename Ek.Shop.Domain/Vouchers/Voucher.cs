using Ek.Shop.Domain.Orders;
using System.Collections.Generic;

namespace Ek.Shop.Domain.Vouchers
{
    public class Voucher : Entity
    {
        public Voucher()
        {
            Orders = new HashSet<Order>();
        }

        public int Count { get; set; }

        public decimal Discount { get; set; }

        public string Name { get; set; }
        
        public virtual ICollection<Order> Orders { get; set; }
    }
}
