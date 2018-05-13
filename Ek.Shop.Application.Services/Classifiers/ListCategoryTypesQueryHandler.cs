using Ek.Shop.Application.Classifiers;
using Ek.Shop.Base.Application.Services.QueryHandlers.ClassifierQueryHandler;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Domain.Categories;

namespace Ek.Shop.Application.Services.Classifiers
{
    public class ListCategoryTypesQueryHandler : ClassifierQueryHandler<ListCategoryTypesCommand, CategoryType, CategoryTypeDto>
    {
        public ListCategoryTypesQueryHandler(IClassifierBus<ListCategoryTypesCommand, CategoryType> classifierBus)
            : base(classifierBus)
        { }
    }
}
