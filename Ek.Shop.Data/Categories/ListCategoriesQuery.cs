using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Enums;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Categories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Data.Categories
{
    public class ListCategoriesQuery : RemoteQuery<ListCategoriesCommand, PagedList<Category>>
    {
        public ListCategoriesQuery(EkShopContext dbContext)
            : base(dbContext)
        { }

        public override async Task<PagedList<Category>> Query(ListCategoriesCommand command)
        {
            // ServerSide paging of category list is doing in query handler only because it is too difficult to properly form navigations
            var query = DbContext.Categories
                .Include(o => o.Characteristics).ThenInclude(o => o.Characteristic)
                .Include(o => o.Characteristics)
                .Include(o => o.CategoryType)
                .Include(o => o.Route).ThenInclude(o => o.AngularComponent)
                .Include(o => o.Images).ThenInclude(o => o.ImageSizeType)
                .Include(o => o.Images).ThenInclude(o => o.Characteristics).ThenInclude(o => o.Characteristic)
                .Include(o => o.Images).ThenInclude(o => o.Characteristics)
                .Where(o => o.Route.InputFormId == command.InputFormId || (command.IsDefaultCategoriesIncluded && o.Route.InputForm.Code == InputFormCodes.CommonInputForm));

            if (!string.IsNullOrWhiteSpace(command.Search))
            {
                query = query.Where(o => o.Characteristics.Any(i => i.Characteristic.Code == CharacteristicCodes.Name && i.Value.Contains(command.Search)));
            }

            var pagedList = await query.ToPagedListAsync();

            var categoryCharacteristicIds = pagedList.Items.SelectMany(o => o.Characteristics).Select(o => o.Id).Union(pagedList.Items.Where(o => o.Children != null).SelectMany(o => o.Children).SelectMany(o => o.Characteristics).Select(o => o.Id));
            await DbContext.CategoryCharacteristicTranslations.Where(o => categoryCharacteristicIds.Contains(o.CharacteristicId) && o.LanguageId == command.LanguageId).LoadAsync();

            var categoryImageCharacteristicIds = pagedList.Items.SelectMany(o => o.Images).SelectMany(o => o.Characteristics).Select(o => o.Id).Union(pagedList.Items.Where(o => o.Children != null).SelectMany(o => o.Children).SelectMany(o => o.Images).SelectMany(o => o.Characteristics).Select(o => o.Id));
            await DbContext.ImageCharacteristicTranslations.Where(o => categoryImageCharacteristicIds.Contains(o.CharacteristicId) && o.LanguageId == command.LanguageId).LoadAsync();

            pagedList.Items = pagedList.Items
                .Where(o => command.IsDisabledIncluded || (!command.IsDisabledIncluded && o.Characteristics.FirstOrDefault(i => i.Characteristic?.Code == CharacteristicCodes.IsDisabled)?.Value != "true"));

            pagedList.Items = pagedList.Items
                .OrderBy(o => o.Characteristics.FirstOrDefault(i => i.Characteristic.Code == CharacteristicCodes.Order)?.Value == null)
                .ThenBy(o => o.Characteristics.FirstOrDefault(i => i.Characteristic.Code == CharacteristicCodes.Order)?.Value)
                .ThenBy(o => o.Characteristics.FirstOrDefault(i => i.Characteristic.Code == CharacteristicCodes.NavigationName)?.Value ?? o.Characteristics.FirstOrDefault(i => i.Characteristic.Code == CharacteristicCodes.Name)?.Value);

            return pagedList;
        }
    }
}
