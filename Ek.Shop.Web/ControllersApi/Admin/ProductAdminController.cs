using Ek.Shop.Application.Products;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Ek.Shop.Web.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ek.Shop.Web.ControllersApi.Admin
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class ProductAdminController : AdminController
    {
        public ProductAdminController(IBus bus)
            : base(bus)
        { }

        [HttpPost("[action]")]
        public async Task<IActionResult> DeleteProduct([FromBody]int id)
        {
            var productDtoResult = await QueryProcessor.GetQueryHandler<DeleteProductCommand, ProductDto>(new DeleteProductCommand(id));
            if (productDtoResult.Failure)
            {
                return BadRequest(productDtoResult.ErrorMessages);
            }

            return Ok(productDtoResult.Success);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetEditProductData(int id, int languageId)
        {
            var editProductDataDtoResult = await QueryProcessor.GetQueryHandler<EditProductCommand, EditProductDataDto>(new EditProductCommand(id, languageId));
            if (editProductDataDtoResult.Failure)
            {
                return BadRequest(editProductDataDtoResult.ErrorMessages);
            }

            var editProductDataDto = editProductDataDtoResult.Object;
            return Ok(editProductDataDto);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ListProducts(ListProductsCommand listProductsCommand)
        {
            // TODO: fix workingLanguageId
            listProductsCommand.LanguageId = 1;
            var pagedProductsDtoResult = await QueryProcessor.GetQueryHandler<ListProductsCommand, PagedList<ProductDto>>(listProductsCommand);
            if (pagedProductsDtoResult.Failure)
            {
                return BadRequest(pagedProductsDtoResult.ErrorMessages);
            }

            var pagedProductsDto = pagedProductsDtoResult.Object;
            return Ok(pagedProductsDto);
        }

        // TODO: Take languageId parameter from client
        [HttpPost("[action]")]
        public async Task<IActionResult> SaveProduct([FromBody]SaveProductDto saveProduct)
        {
            var productDtoResult = await QueryProcessor.GetQueryHandler<SaveProductCommand, ProductDto>(new SaveProductCommand(saveProduct, 1));
            if (productDtoResult.Failure)
            {
                return BadRequest(productDtoResult.ErrorMessages);
            }

            return Ok(productDtoResult.Object);
        }
    }
}
