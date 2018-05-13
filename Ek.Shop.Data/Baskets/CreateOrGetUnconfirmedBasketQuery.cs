using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Domain.Baskets;
using Ek.Shop.Domain.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Data.Baskets
{
    public class CreateOrGetUnconfirmedBasketQuery : RemoteQuery<CreateOrGetUnconfirmedBasketCommand, Basket>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public CreateOrGetUnconfirmedBasketQuery(EkShopContext dbContext,
            IHttpContextAccessor httpContextAccessor,
            UserManager<User> userManager)
            : base (dbContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public override bool IsCacheRequired => false;

        public override async Task<Basket> Query(CreateOrGetUnconfirmedBasketCommand command)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            if (user == null)
            {
                return null;
            }

            var basket = await DbContext.Baskets
                .Include(o => o.BasketItems)
                .Where(o => o.UserId == user.Id && !o.IsConfirmed)
                .FirstOrDefaultAsync();

            if (basket == null)
            {
                basket = new Basket() { UserId = user.Id };
                DbContext.AddOrUpdate(basket);
                await DbContext.SaveChangesAsync();
            }
            else if (basket.BasketItems.Any(o => !o.ProductId.HasValue))
            {
                foreach (var basketItem in basket.BasketItems.Where(o => !o.ProductId.HasValue))
                {
                    DbContext.ActionByEntityState(basketItem, EntityState.Deleted);
                }

                await DbContext.SaveChangesAsync();
            }

            return basket;
        }
    }
}
