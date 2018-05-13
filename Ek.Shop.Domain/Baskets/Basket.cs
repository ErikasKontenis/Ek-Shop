using Ek.Shop.Domain.Orders;
using Ek.Shop.Domain.Users;
using System.Collections.Generic;
using System.Linq;

namespace Ek.Shop.Domain.Baskets
{
    public class Basket : Entity
    {
        public Basket()
        {
            BasketItems = new HashSet<BasketItem>();
            Orders = new HashSet<Order>();
        }

        public ICollection<BasketItem> BasketItems { get; set; }

        public bool IsConfirmed { get; set; }

        public ICollection<Order> Orders { get; set; }

        public virtual User User { get; set; }

        public int UserId { get; set; }

        public decimal GetTotalPrice()
        {
            return BasketItems.Sum(o => o.GetTotalPrice());
        }
    }
}
