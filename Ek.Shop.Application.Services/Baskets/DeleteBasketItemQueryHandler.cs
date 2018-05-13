using Ek.Shop.Application.Baskets;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Baskets;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Baskets
{
    public class DeleteBasketItemQueryHandler : QueryHandler<DeleteBasketItemCommand, BasketItemDto>
    {
        private readonly IRemoteQuery<DeleteBasketItemCommand, BasketItem> _deleteBasketItemQuery;

        public DeleteBasketItemQueryHandler(IRemoteQuery<DeleteBasketItemCommand, BasketItem> deleteBasketItemQuery)
        {
            _deleteBasketItemQuery = deleteBasketItemQuery;
        }

        public override async Task<ActionResult<BasketItemDto>> Handle(DeleteBasketItemCommand command)
        {
            var basketItem = await _deleteBasketItemQuery.Query(command);
            if (basketItem == null)
            {
                return Error();
            }

            return Ok(new BasketItemDto());
        }
    }
}
