using AutoMapper;
using Ek.Shop.Application.Classifiers;
using Ek.Shop.Application.Extensions;
using Ek.Shop.Application.InputForms;
using Ek.Shop.Application.Services.AutoMappers;
using Ek.Shop.Application.Services.AutoMappers.Profiles;
using Ek.Shop.Application.Services.Infrastructure.CommonHelpers;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Contracts.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Core.Models;
using Ek.Shop.Data.ClassifierStores;
using Ek.Shop.Domain.Categories;
using Ek.Shop.Domain.Characteristics;
using Ek.Shop.Domain.Phrases;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Categories
{
    public class SaveCategoryQueryHandler : QueryHandler<SaveCategoryCommand, CategoryDto>
    {
        private readonly IQueryHandler<GetInputFormCommand, InputFormDto> _getInputFormQueryHandler;
        private readonly IQueryHandler<GetCategoryByUrlCommand, CategoryDto> _getCategoryByUrlQueryHandler;
        private readonly IRemoteQuery<GetCategoryCommand, Category> _getCategoryQuery;
        private readonly IRemoteQuery<ListCharacteristicsCommand, List<Characteristic>> _listCharacteristicsQuery;
        private readonly IRemoteQuery<GetPhraseByValueCommand, Phrase> _getPhraseByValueQuery;
        private readonly IRemoteQuery<SaveCategoryQueryCommand, Category> _saveCategoryQuery;
        private readonly IClassifierStoresRepository _classifierStoresRepository;

        private IMapper _mapper => AutoMapperFactory
            .CreateMapper<CategoryMapperProfile, ImageMapperProfile>();

        public SaveCategoryQueryHandler(IQueryHandler<GetInputFormCommand, InputFormDto> getInputFormQueryHandler,
            IQueryHandler<GetCategoryByUrlCommand, CategoryDto> getCategoryByUrlQueryHandler,
            IRemoteQuery<GetCategoryCommand, Category> categoryQuery,
            IRemoteQuery<ListCharacteristicsCommand, List<Characteristic>> listCharacteristicsQuery,
            IRemoteQuery<GetPhraseByValueCommand, Phrase> getPhraseByValueQuery,
            IRemoteQuery<SaveCategoryQueryCommand, Category> saveCategoryQuery,
            IClassifierStoresRepository classifierStoresRepository)
        {
            _getInputFormQueryHandler = getInputFormQueryHandler;
            _getCategoryByUrlQueryHandler = getCategoryByUrlQueryHandler;
            _getCategoryQuery = categoryQuery;
            _listCharacteristicsQuery = listCharacteristicsQuery;
            _getPhraseByValueQuery = getPhraseByValueQuery;
            _saveCategoryQuery = saveCategoryQuery;
            _classifierStoresRepository = classifierStoresRepository;
        }

        public override async Task<ActionResult<CategoryDto>> Handle(SaveCategoryCommand command)
        {
            var saveCategoryDtoResult = await _getCategoryByUrlQueryHandler.Handle(new GetCategoryByUrlCommand(command.SaveCategory.RouteUrl, command.LanguageId));
            if (saveCategoryDtoResult.Failure)
            {
                return Error(saveCategoryDtoResult.ErrorMessages);
            }

            var saveCategoryDto = saveCategoryDtoResult.Object;
            var detailErrors = saveCategoryDto.Fieldsets.MapToFields(command.SaveCategory.Category).ValidateFieldsets();
            if (!detailErrors.IsNullOrEmpty())
            {
                return Error(detailErrors);
            }

            var classifierStore = await _classifierStoresRepository.Get();
            var availableCharacteristics = await _listCharacteristicsQuery.Query(new ListCharacteristicsCommand());
            var category = await _getCategoryQuery.Query(new GetCategoryCommand(command.SaveCategory.Category.Id, command.LanguageId, true)) ?? new Category();
            var categoryDto = command.SaveCategory.Category;
            categoryDto = await CategoryDtoDefaults(categoryDto);

            _mapper.Map(categoryDto, category);

            category.Route.AngularComponentId = classifierStore.AngularComponents.First(o => o.Code == categoryDto.AngularComponentCode).Id;
            category.CategoryTypeId = classifierStore.CategoryTypes.First(o => o.Code == categoryDto.CategoryTypeCode).Id;

            category.Images.MergeImages(availableCharacteristics, categoryDto.Images);
            category.Characteristics.MergeCharacteristics(availableCharacteristics, categoryDto.Characteristics);

            await _saveCategoryQuery.Query(new SaveCategoryQueryCommand(category));

            return Ok(categoryDto);
        }

        private async Task<CategoryDto> CategoryDtoDefaults(CategoryDto category)
        {
            if (category.InputFormId == 0)
            {
                var commonInputForm = (await _getInputFormQueryHandler.Handle(new GetInputFormCommand(InputFormCodes.CommonInputForm))).Object;
                category.InputFormId = commonInputForm.Id;
            }

            return category;
        }
    }
}