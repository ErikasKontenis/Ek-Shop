using Ek.Shop.Application.Baskets;
using Ek.Shop.Application.Products;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Base.Data.WorkContexts;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Contracts.Extensions;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Baskets;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Baskets
{
    public class CreateOrGetUnconfirmedBasketQueryHandler : QueryHandler<CreateOrGetUnconfirmedBasketCommand, BasketDto>
    {
        private readonly IQueryHandler<GetProductCommand, ProductDto> _getProductQueryHandler;
        private readonly IRemoteQuery<CreateOrGetUnconfirmedBasketCommand, Basket> _createOrGetUnconfirmedBasketQuery;
        private readonly IWorkContext _workContext;

        public CreateOrGetUnconfirmedBasketQueryHandler(IQueryHandler<GetProductCommand, ProductDto> getProductQueryHandler,
            IRemoteQuery<CreateOrGetUnconfirmedBasketCommand, Basket> createOrGetUnconfirmedBasketQuery,
            IWorkContext workContext)
        {
            _getProductQueryHandler = getProductQueryHandler;
            _createOrGetUnconfirmedBasketQuery = createOrGetUnconfirmedBasketQuery;
            _workContext = workContext;
        }

        public override async Task<ActionResult<BasketDto>> Handle(CreateOrGetUnconfirmedBasketCommand command)
        {
            var basket = await _createOrGetUnconfirmedBasketQuery.Query(command);
            if (basket == null)
            {
                // if basket is null then send user is not authenticated error
                // TODO: take this info from phrases
                return Error();
            }

            var basketDto = new BasketDto();
            basketDto.Id = basket.Id;

            if (basket.BasketItems.IsNullOrEmpty())
                return Ok(basketDto);

            foreach (var basketItem in basket.BasketItems)
            {
                var basketItemDto = new BasketItemDto();
                var productDto = (await _getProductQueryHandler.Handle(new GetProductCommand(basketItem.ProductId.Value, _workContext.WorkingLanguageId))).Object;
                basketItemDto.Id = basketItem.Id;
                basketItemDto.Product = productDto;
                basketItemDto.Price = basketItem.Price;
                basketItemDto.ProductDetailId = basketItem.ProductDetailId;
                basketItemDto.Quantity = basketItem.Quantity;

                basketDto.BasketItems.Add(basketItemDto);
            }

            return Ok(basketDto);
        }
    }
}
