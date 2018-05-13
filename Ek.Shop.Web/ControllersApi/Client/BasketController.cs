using Ek.Shop.Application.Baskets;
using Ek.Shop.Application.Products;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ek.Shop.Web.ControllersApi.Client
{
    [ResponseCache(CacheProfileName = "ResponseCachingNever")]
    [Route("api/[controller]")]
    public class BasketController : ClientController
    {
        public BasketController(IBus bus)
            : base(bus)
        { }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddProductToBasket([FromBody]AddProductToBasketCommand command)
        {
            var productDtoResult = await QueryProcessor.GetQueryHandler<AddProductToBasketCommand, ProductDto>(command);
            if (productDtoResult.Failure)
            {
                return BadRequest(productDtoResult.ErrorMessages);
            }

            var productDto = productDtoResult.Object;
            return Ok(productDto);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> DeleteBasketItem([FromBody]DeleteBasketItemCommand command)
        {
            var basketItemDtoResult = await QueryProcessor.GetQueryHandler<DeleteBasketItemCommand, BasketItemDto>(command);
            if (basketItemDtoResult.Failure)
            {
                return BadRequest(basketItemDtoResult.ErrorMessages);
            }

            var basketItemDto = basketItemDtoResult.Object;
            return Ok(basketItemDto);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBasket()
        {
            var basketDtoResult = await QueryProcessor.GetQueryHandler<CreateOrGetUnconfirmedBasketCommand, BasketDto>(new CreateOrGetUnconfirmedBasketCommand());
            if (basketDtoResult.Failure)
            {
                return BadRequest(basketDtoResult.ErrorMessages);
            }

            var basketDto = basketDtoResult.Object;
            return Ok(basketDto);
        }
    }
}
