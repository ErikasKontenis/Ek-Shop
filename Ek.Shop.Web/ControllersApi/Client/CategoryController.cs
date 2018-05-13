using Ek.Shop.Application.Classifiers;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Ek.Shop.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ek.Shop.Web.ControllersApi.Client
{
    [ResponseCache(CacheProfileName = "ResponseCachingDefault")]
    [Route("api/[controller]")]
    public class CategoryController : ClientController
    {
        public CategoryController(IBus bus)
            : base(bus)
        { }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCategoryNavigations()
        {
            var listCategoriesCommand = new ListCategoriesCommand(2, WorkContext.WorkingLanguageId, true);
            var pagedNavigationsDtoResult = await QueryProcessor.GetQueryHandler<ListCategoriesCommand, PagedList<CategoryNavigationDto>>(listCategoriesCommand);
            if (pagedNavigationsDtoResult.Failure)
            {
                return BadRequest(pagedNavigationsDtoResult.ErrorMessages);
            }

            var pagedNavigationsDto = pagedNavigationsDtoResult.Object;
            return Ok(pagedNavigationsDto.Items);
        }
    }
}
