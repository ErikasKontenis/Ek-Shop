using Ek.Shop.Application.Classifiers;
using Ek.Shop.Application.Products;
using Ek.Shop.Application.Routes;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Enums;
using Ek.Shop.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ek.Shop.Web.ControllersApi.Common
{
    [ResponseCache(CacheProfileName = "ResponseCachingDefault")]
    [Route("api/[controller]")]
    public class ComponentFactoryController : ApiControllerAsync
    {
        public ComponentFactoryController(IBus bus)
            : base(bus)
        { }

        [HttpGet("[action]")]
        public async Task<IActionResult> Create(string url)
        {
            url = url?.TrimStart('/') ?? "";
            var urlPath = url.Split('?').First();

            if (Regex.IsMatch(urlPath.Split('/').Last(), @"^\d+$"))
            {
                urlPath = urlPath.Substring(0, urlPath.LastIndexOf("/"));
            }

            var routeDtoResult = await QueryProcessor.GetQueryHandler<GetRouteByUrlCommand, RouteDto>(new GetRouteByUrlCommand(urlPath, WorkContext.WorkingLanguageId));
            if (routeDtoResult.Failure)
            {
                return BadRequest(routeDtoResult.ErrorMessages);
            }

            var currentRouteDto = routeDtoResult.Object;
            if (currentRouteDto == null)
            {
                // TODO: 404
                return NotFound();
            }

            if (currentRouteDto.AngularComponent != AngularComponents.ProductComponent)
            {
                var getCategoryCommand = new GetCategoryCommand(currentRouteDto.ItemId.Value, WorkContext.WorkingLanguageId);
                return await CreateCategory(getCategoryCommand);
            }
            else
            {
                var getProductCommand = new GetProductCommand(currentRouteDto.ItemId.Value, WorkContext.WorkingLanguageId);
                return await CreateProduct(getProductCommand);
            }
        }

        private async Task<IActionResult> CreateCategory(GetCategoryCommand command)
        {
            var categoryDtoResult = await QueryProcessor.GetQueryHandler<GetCategoryCommand, CategoryDto>(command);
            if (categoryDtoResult.Failure)
            {
                return BadRequest(categoryDtoResult);
            }

            var categoryDto = categoryDtoResult.Object;
            return Ok(categoryDto);
        }

        private async Task<IActionResult> CreateProduct(GetProductCommand command)
        {
            var productDtoResult = await QueryProcessor.GetQueryHandler<GetProductCommand, ProductDto>(command);
            if (productDtoResult.Failure)
            {
                return BadRequest(productDtoResult.ErrorMessages);
            }

            var productDto = productDtoResult.Object;
            return Ok(productDto);
        }
    }
}
