using Ek.Shop.Application.Products;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Ek.Shop.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ek.Shop.Web.ControllersApi.Client
{
    [ResponseCache(CacheProfileName = "ResponseCachingDefault")]
    [Route("api/[controller]")]
    public class ProductController : ClientController
    {
        public ProductController(IBus bus)
            : base(bus)
        { }

        // TODO: Take languageId parameter from client
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var productDtoResult = await QueryProcessor.GetQueryHandler<GetProductCommand, ProductDto>(new GetProductCommand(id, 1));
            if (productDtoResult.Failure)
            {
                return BadRequest(productDtoResult.ErrorMessages);
            }

            var productDto = productDtoResult.Object;
            return Ok(productDto);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ListProductsByCategory(ListProductsByCategoryCommand listProductsByCategoryCommand)
        {
            // TODO: fix workingLanguageId
            listProductsByCategoryCommand.LanguageId = 1;
            var pagedProductsDtoResult = await QueryProcessor.GetQueryHandler<ListProductsByCategoryCommand, PagedList<ProductDto>>(listProductsByCategoryCommand);
            if (pagedProductsDtoResult.Failure)
            {
                return BadRequest(pagedProductsDtoResult.ErrorMessages);
            }

            var pagedProductsDto = pagedProductsDtoResult.Object;
            return Ok(pagedProductsDto);
        }
    }
}
