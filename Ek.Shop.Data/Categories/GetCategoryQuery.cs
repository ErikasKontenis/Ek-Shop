using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Base.Data.Queries.Queries;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Base.Data.WorkContexts;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.Categories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Data.Categories
{
    public class GetCategoryQuery : RemoteQuery<GetCategoryCommand, Category>
    {
        private readonly IQuery<GetCategoryCommand, Category> _categoryBaseQuery;
        private readonly IWorkContext _workContext;

        public GetCategoryQuery(EkShopContext dbContext,
            IQuery<GetCategoryCommand, Category> categoryBaseQuery,
            IWorkContext workContext)
            : base (dbContext)
        {
            _categoryBaseQuery = categoryBaseQuery;
            _workContext = workContext;
        }

        public override async Task<Category> Query(GetCategoryCommand command)
        {
            var categoriesQuery = _categoryBaseQuery.Execute(command);

            var categories = await categoriesQuery
                .Include(o => o.Route).ThenInclude(o => o.AngularComponent).ThenInclude(o => o.InputFieldsets).ThenInclude(o => o.InputForm)
                .Include(o => o.Route).ThenInclude(o => o.AngularComponent).ThenInclude(o => o.InputFieldsets).ThenInclude(o => o.Characteristics)
                .Include(o => o.Route).ThenInclude(o => o.AngularComponent).ThenInclude(o => o.InputFieldsets).ThenInclude(o => o.InputFields).ThenInclude(o => o.Characteristics).ThenInclude(o => o.Characteristic)
                .Include(o => o.Route).ThenInclude(o => o.AngularComponent).ThenInclude(o => o.InputFieldsets).ThenInclude(o => o.InputFields).ThenInclude(o => o.Characteristics)
                .Include(o => o.Route).ThenInclude(o => o.AngularComponent).ThenInclude(o => o.InputFieldsets).ThenInclude(o => o.Characteristics).ThenInclude(o => o.Characteristic)
                .Include(o => o.Route).ThenInclude(o => o.AngularComponent).ThenInclude(o => o.InputFieldsets).ThenInclude(o => o.Characteristics)
                .Include(o => o.Route).ThenInclude(o => o.AngularComponent).ThenInclude(o => o.InputFieldsets).ThenInclude(o => o.InputFields).ThenInclude(o => o.Characteristics).ThenInclude(o => o.Characteristic)
                .Include(o => o.Route).ThenInclude(o => o.AngularComponent).ThenInclude(o => o.InputFieldsets).ThenInclude(o => o.InputFields).ThenInclude(o => o.Characteristics)
                .Include(o => o.Fieldsets).ThenInclude(o => o.Characteristics).ThenInclude(o => o.Characteristic)
                .Include(o => o.Fieldsets).ThenInclude(o => o.Characteristics)
                .Include(o => o.Fieldsets).ThenInclude(o => o.InputFields).ThenInclude(o => o.Characteristics).ThenInclude(o => o.Characteristic)
                .Include(o => o.Fieldsets).ThenInclude(o => o.InputFields).ThenInclude(o => o.Characteristics)
                .Where(o => o.Route.InputFormId == _workContext.WorkingInputFormId || o.Route.InputForm.Code == InputFormCodes.CommonInputForm)
                .ToListAsync();

            var categoryCharacteristicIds = categories.SelectMany(o => o.Characteristics).Select(o => o.Id).Union(categories.Where(o => o.Children != null).SelectMany(o => o.Children).SelectMany(o => o.Characteristics).Select(o => o.Id));
            await DbContext.CategoryCharacteristicTranslations.Where(o => categoryCharacteristicIds.Contains(o.CharacteristicId) && o.LanguageId == command.LanguageId).LoadAsync();

            var categoryImageCharacteristicIds = categories.SelectMany(o => o.Images).SelectMany(o => o.Characteristics).Select(o => o.Id).Union(categories.Where(o => o.Children != null).SelectMany(o => o.Children).SelectMany(o => o.Images).SelectMany(o => o.Characteristics).Select(o => o.Id));
            await DbContext.ImageCharacteristicTranslations.Where(o => categoryImageCharacteristicIds.Contains(o.CharacteristicId) && o.LanguageId == command.LanguageId).LoadAsync();

            var inputFieldsetCharacteristicIds = categories.SelectMany(o => o.Fieldsets).SelectMany(o => o.Characteristics).Select(o => o.Id).Union(categories.Select(o => o.Route).Select(o => o.AngularComponent).SelectMany(o => o.InputFieldsets).SelectMany(o => o.Characteristics).Select(o => o.Id));
            await DbContext.InputFieldsetCharacteristicTranslations.Where(o => inputFieldsetCharacteristicIds.Contains(o.CharacteristicId) && o.LanguageId == command.LanguageId).LoadAsync();

            var inputFieldCharacteristicIds = categories.SelectMany(o => o.Fieldsets).SelectMany(o => o.InputFields).SelectMany(o => o.Characteristics).Select(o => o.Id).Union(categories.Select(o => o.Route).Select(o => o.AngularComponent).SelectMany(o => o.InputFieldsets).SelectMany(o => o.InputFields).SelectMany(o => o.Characteristics).Select(o => o.Id));
            await DbContext.InputFieldCharacteristicTranslations.Where(o => inputFieldCharacteristicIds.Contains(o.CharacteristicId) && o.LanguageId == command.LanguageId).LoadAsync();

            var characteristics = categories.SelectMany(o => o.Characteristics);
            foreach (var characteristic in characteristics)
                characteristic.Translations = DbContext.CategoryCharacteristicTranslations.Where(o => o.CharacteristicId == characteristic.Id && o.LanguageId == command.LanguageId).ToList();

            var filteredCategories = categories
                .Where(o => command.IsDisabledIncluded || (!command.IsDisabledIncluded && o.Characteristics.FirstOrDefault(i => i.Characteristic?.Code == CharacteristicCodes.IsDisabled)?.Value != "true"))
                .DistinctByActiveInputForm(_workContext);

            return filteredCategories.FirstOrDefault(o => o.Id == command.CategoryId);
        }
    }
}
