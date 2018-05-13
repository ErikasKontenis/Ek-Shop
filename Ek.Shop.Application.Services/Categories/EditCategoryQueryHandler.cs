using Ek.Shop.Application.Classifiers;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Contracts.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Categories
{
    public class EditCategoryQueryHandler : QueryHandler<EditCategoryCommand, EditCategoryDataDto>
    {
        private readonly IQueryHandler<GetCategoryCommand, CategoryDto> _getCategoryQueryHandler;
        private readonly IQueryHandler<ListCategoriesCommand, PagedList<CategoryDto>> _listCategoriesQueryHandler;
        private readonly IQueryHandler<ListCategoryTypesCommand, List<CategoryTypeDto>> _listCategoryTypesQueryHandler;
        private readonly IQueryHandler<ListAngularComponentsCommand, List<AngularComponentDto>> _listAngularComponentsQueryHandler;

        public EditCategoryQueryHandler(IQueryHandler<GetCategoryCommand, CategoryDto> getCategoryQueryHandler,
            IQueryHandler<ListCategoriesCommand, PagedList<CategoryDto>> listCategoriesQueryHandler,
            IQueryHandler<ListCategoryTypesCommand, List<CategoryTypeDto>> listCategoryTypesQueryHandler,
            IQueryHandler<ListAngularComponentsCommand, List<AngularComponentDto>> listAngularComponentsQueryHandler)
        {
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _listCategoriesQueryHandler = listCategoriesQueryHandler;
            _listCategoryTypesQueryHandler = listCategoryTypesQueryHandler;
            _listAngularComponentsQueryHandler = listAngularComponentsQueryHandler;
        }

        public override async Task<ActionResult<EditCategoryDataDto>> Handle(EditCategoryCommand command)
        {
            var categoryDtoResult = await _getCategoryQueryHandler.Handle(new GetCategoryCommand(command.CategoryId, command.LanguageId, true));
            if (categoryDtoResult.Failure && command.CategoryId > 0)
            {
                return Error(categoryDtoResult.ErrorMessages);
            }

            var pagedCategoriesDtoResult = await _listCategoriesQueryHandler.Handle(new ListCategoriesCommand(2, command.LanguageId, true));
            if (pagedCategoriesDtoResult.Failure)
            {
                return Error(pagedCategoriesDtoResult.ErrorMessages);
            }

            var categoryTypesDtoResult = await _listCategoryTypesQueryHandler.Handle(new ListCategoryTypesCommand());
            if (categoryTypesDtoResult.Failure)
            {
                return Error(categoryTypesDtoResult.ErrorMessages);
            }

            var angularComponentsDtoResult = await _listAngularComponentsQueryHandler.Handle(new ListAngularComponentsCommand());
            if (angularComponentsDtoResult.Failure)
            {
                return Error(angularComponentsDtoResult.ErrorMessages);
            }

            var categoryDto = categoryDtoResult.Object ?? new CategoryDto();
            var pagedCategoriesDto = pagedCategoriesDtoResult.Object;
            var categoryTypesDto = categoryTypesDtoResult.Object;
            var angularComponentsDto = angularComponentsDtoResult.Object;

            var editCategoryDataDto = new EditCategoryDataDto();
            editCategoryDataDto.Category = categoryDto;
            editCategoryDataDto.CategoryTypes = categoryTypesDto;
            editCategoryDataDto.AngularComponents = angularComponentsDto;
            editCategoryDataDto.ParentCategories = pagedCategoriesDto.Items.Select(o => new CategoryClassifierDto()
            {
                Text = o.Characteristics.GetValue(CharacteristicCodes.Name),
                Value = o.Id
            }).ToList();

            return Ok(editCategoryDataDto);
        }
    }
}
