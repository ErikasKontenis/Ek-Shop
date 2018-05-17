using Ek.Shop.Contracts.Abstractions;
using Ek.Shop.Core.Enums;

namespace Ek.Shop.Contracts.Commands
{
    public class GetCategoryCommand : CachingCommand
    {
        public GetCategoryCommand()
        { }

        public GetCategoryCommand(int categoryId, int languageId, bool isDisabledIncluded = false)
        {
            CategoryId = categoryId;
            LanguageId = languageId;
            IsDisabledIncluded = isDisabledIncluded;
        }

        public int CategoryId { get; set; }

        public bool IsDisabledIncluded { get; set; }

        public int LanguageId { get; set; }

        public override string Region => CacheRegions.Category;
    }
}
