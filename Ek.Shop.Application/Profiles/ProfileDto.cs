using Ek.Shop.Application.Orders;
using Ek.Shop.Core.Models;

namespace Ek.Shop.Application.Profiles
{
    public class ProfileDto
    {
        public PagedList<OrderDto> Orders { get; set; }
    }
}
