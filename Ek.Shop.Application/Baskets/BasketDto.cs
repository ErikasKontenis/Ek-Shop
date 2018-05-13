using System.Collections.Generic;
using System.Linq;

namespace Ek.Shop.Application.Baskets
{
    public class BasketDto
    {
        public List<BasketItemDto> BasketItems { get; set; } = new List<BasketItemDto>();

        public int Id { get; set; }

        public decimal GetTotalPrice()
        {
            return BasketItems.Sum(o => o.GetTotalPrice());
        }
    }
}
