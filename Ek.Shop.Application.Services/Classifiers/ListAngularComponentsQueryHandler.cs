using Ek.Shop.Application.Classifiers;
using Ek.Shop.Base.Application.Services.QueryHandlers.ClassifierQueryHandler;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Domain.AngularComponents;

namespace Ek.Shop.Application.Services.Classifiers
{
    public class ListAngularComponentsQueryHandler : ClassifierQueryHandler<ListAngularComponentsCommand, AngularComponent, AngularComponentDto>
    {
        public ListAngularComponentsQueryHandler(IClassifierBus<ListAngularComponentsCommand, AngularComponent> classifierBus)
            : base(classifierBus)
        { }
    }
}
