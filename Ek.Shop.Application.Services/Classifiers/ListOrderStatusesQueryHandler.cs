using Ek.Shop.Application.Classifiers;
using Ek.Shop.Base.Application.Services.QueryHandlers.ClassifierQueryHandler;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Domain.Orders;

namespace Ek.Shop.Application.Services.Classifiers
{
    public class ListOrderStatusesQueryHandler : ClassifierQueryHandler<ListOrderStatusesCommand, OrderStatus, OrderStatusDto>
    {
        public ListOrderStatusesQueryHandler(IClassifierBus<ListOrderStatusesCommand, OrderStatus> classifierBus)
            : base(classifierBus)
        { }
    }
}
