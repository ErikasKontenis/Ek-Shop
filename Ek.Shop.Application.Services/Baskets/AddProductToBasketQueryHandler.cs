using Ek.Shop.Application.Extensions;
using Ek.Shop.Application.Products;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Base.Data.WorkContexts;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Contracts.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Baskets;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Baskets
{
    public class AddProductToBasketQueryHandler : QueryHandler<AddProductToBasketCommand, ProductDto>
    {
        private readonly IQueryHandler<GetProductCommand, ProductDto> _getProductQueryHandler;
        private readonly IRemoteQuery<AddProductToBasketCommand, Basket> _addProductToBasketQuery;
        private readonly IWorkContext _workContext;

        public AddProductToBasketQueryHandler(IQueryHandler<GetProductCommand, ProductDto> getProductQueryHandler,
            IRemoteQuery<AddProductToBasketCommand, Basket> addProductToBasketQuery,
            IWorkContext workContext)
        {
            _getProductQueryHandler = getProductQueryHandler;
            _addProductToBasketQuery = addProductToBasketQuery;
            _workContext = workContext;
        }

        public override async Task<ActionResult<ProductDto>> Handle(AddProductToBasketCommand command)
        {
            var productDtoResult = await _getProductQueryHandler.Handle(new GetProductCommand(command.ProductId, _workContext.WorkingLanguageId));
            if (productDtoResult.Failure)
            {
                return Error(productDtoResult.ErrorMessages);
            }

            var productDto = productDtoResult.Object;
            var detailErrors = productDto.Fieldsets.MapToFields(command).ValidateFieldsets();
            if (!detailErrors.IsNullOrEmpty())
            {
                return Error(detailErrors);
            }

            var basket = await _addProductToBasketQuery.Query(command);
            if (basket == null)
            {
                // if basket is null then send user is not authenticated error
                // TODO: take this info from phrases
                return Error(new Dictionary<string, DetailError>() { { "baseProductBody" + "." + "basketAdd", new DetailError(DetailErrorTypes.Field, "Prašome pirmiau prisijungti.") } });
            }

            return Ok(productDto);
        }
    }
}
