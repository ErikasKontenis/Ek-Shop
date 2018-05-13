using Ek.Shop.Application.Classifiers;
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
    public class CategoryAdminController : AdminController
    {
        public CategoryAdminController(IBus bus)
            : base(bus)
        { }

        [HttpPost("[action]")]
        public async Task<IActionResult> DeleteCategory([FromBody]int id)
        {
            var categoryDtoResult = await QueryProcessor.GetQueryHandler<DeleteCategoryCommand, CategoryDto>(new DeleteCategoryCommand(id));
            if (categoryDtoResult.Failure)
            {
                return BadRequest(categoryDtoResult.ErrorMessages);
            }

            return Ok(categoryDtoResult.Success);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCategoryNavigations()
        {
            var listCategoriesCommand = new ListCategoriesCommand(1, WorkContext.WorkingLanguageId);
            var pagedNavigationsDtoResult = await QueryProcessor.GetQueryHandler<ListCategoriesCommand, PagedList<CategoryNavigationDto>>(listCategoriesCommand);
            if (pagedNavigationsDtoResult.Failure)
            {
                return BadRequest(pagedNavigationsDtoResult.ErrorMessages);
            }

            var pagedNavigationsDto = pagedNavigationsDtoResult.Object;
            return Ok(pagedNavigationsDto.Items);
        }

        // TODO: Take languageId parameter from client
        [HttpGet("[action]")]
        public async Task<IActionResult> GetEditCategoryData(int id)
        {
            var editCategoryDataDtoResult = await QueryProcessor.GetQueryHandler<EditCategoryCommand, EditCategoryDataDto>(new EditCategoryCommand(id, 1));
            if (editCategoryDataDtoResult.Failure)
            {
                return BadRequest(editCategoryDataDtoResult.ErrorMessages);
            }

            var editCategoryDataDto = editCategoryDataDtoResult.Object;
            return Ok(editCategoryDataDto);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ListCategories(ListCategoriesCommand listCategoriesCommand)
        {
            // TODO: fix workingLanguageId
            listCategoriesCommand.LanguageId = 1;
            listCategoriesCommand.InputFormId = 2; listCategoriesCommand.IsDefaultCategoriesIncluded = true; listCategoriesCommand.IsDisabledIncluded = true;
            var pagedCategoriesDtoResult = await QueryProcessor.GetQueryHandler<ListCategoriesCommand, PagedList<CategoryDto>>(listCategoriesCommand);
            if (pagedCategoriesDtoResult.Failure)
            {
                return BadRequest(pagedCategoriesDtoResult.ErrorMessages);
            }

            var pagedCategoriesDto = pagedCategoriesDtoResult.Object;
            return Ok(pagedCategoriesDto);
        }

        // TODO: Take languageId parameter from client
        [HttpPost("[action]")]
        public async Task<IActionResult> SaveCategory([FromBody]SaveCategoryDto saveCategory)
        {
            var categoryDtoResult = await QueryProcessor.GetQueryHandler<SaveCategoryCommand, CategoryDto>(new SaveCategoryCommand(saveCategory, 1));
            if (categoryDtoResult.Failure)
            {
                return BadRequest(categoryDtoResult.ErrorMessages);
            }

            return Ok(categoryDtoResult.Object);
        }
    }
}
