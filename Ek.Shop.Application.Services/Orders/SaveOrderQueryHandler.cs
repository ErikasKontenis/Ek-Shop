using AutoMapper;
using Ek.Shop.Application.Classifiers;
using Ek.Shop.Application.Extensions;
using Ek.Shop.Application.Orders;
using Ek.Shop.Application.Services.AutoMappers;
using Ek.Shop.Application.Services.AutoMappers.Profiles;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Base.Data.WorkContexts;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Contracts.Extensions;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Orders;
using Ek.Shop.Domain.PaymentMethods;
using Ek.Shop.Domain.Transactions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Orders
{
    public class SaveOrderQueryHandler : QueryHandler<SaveOrderCommand, OrderDto>
    {
        private readonly IQueryHandler<GetCategoryByUrlCommand, CategoryDto> _getCategoryByUrlQueryHandler;
        private readonly IRemoteQuery<ListPaymentMethodsCommand, List<PaymentMethod>> _listPaymentMethodsQuery;
        private readonly IRemoteQuery<ListShippingMethodsCommand, List<ShippingMethod>> _listShippingMethodsQuery;
        private readonly IRemoteQuery<ListOrderStatusesCommand, List<OrderStatus>> _listOrderStatusesQuery;
        private readonly IRemoteQuery<GetOrderCommand, Order> _getOrderQuery;
        private readonly EkShopContext _dbContext;
        private readonly IWorkContext _workContext;

        private IMapper _mapper => AutoMapperFactory
            .CreateMapper<OrderMapperProfile>();

        public SaveOrderQueryHandler(IQueryHandler<GetCategoryByUrlCommand, CategoryDto> getCategoryByUrlQueryHandler,
            IRemoteQuery<ListPaymentMethodsCommand, List<PaymentMethod>> listPaymentMethodsQuery,
            IRemoteQuery<ListShippingMethodsCommand, List<ShippingMethod>> listShippingMethodsQuery,
            IRemoteQuery<ListOrderStatusesCommand, List<OrderStatus>> listOrderStatusesQuery,
            IRemoteQuery<GetOrderCommand, Order> getOrderQuery,
            EkShopContext dbContext,
            IWorkContext workContext)
        {
            _getCategoryByUrlQueryHandler = getCategoryByUrlQueryHandler;
            _listPaymentMethodsQuery = listPaymentMethodsQuery;
            _listShippingMethodsQuery = listShippingMethodsQuery;
            _listOrderStatusesQuery = listOrderStatusesQuery;
            _getOrderQuery = getOrderQuery;
            _dbContext = dbContext;
            _workContext = workContext;
        }

        public override async Task<ActionResult<OrderDto>> Handle(SaveOrderCommand command)
        {
            var editOrderCategoryDtoResult = await _getCategoryByUrlQueryHandler.Handle(new GetCategoryByUrlCommand(command.RouteUrl, _workContext.WorkingLanguageId));
            if (editOrderCategoryDtoResult.Failure)
            {
                return Error(editOrderCategoryDtoResult.ErrorMessages);
            }

            var editOrderCategoryDto = editOrderCategoryDtoResult.Object;
            var orderDto = command.Order;

            var detailErrors = editOrderCategoryDto.Fieldsets.MapToFields(orderDto).ValidateFieldsets();
            if (!detailErrors.IsNullOrEmpty())
            {
                return Error(detailErrors);
            }

            var order = await _getOrderQuery.Query(new GetOrderCommand(command.Order.Id));
            if (order == null)
            {
                return Error();
            }

            _mapper.Map(command.Order, order);

            var paymentMethods = await _listPaymentMethodsQuery.Query(new ListPaymentMethodsCommand());
            var shippingMethods = await _listShippingMethodsQuery.Query(new ListShippingMethodsCommand());
            var orderStatuses = await _listOrderStatusesQuery.Query(new ListOrderStatusesCommand());
            order.PaymentMethodId = paymentMethods.FirstOrDefault(o => o.Code == orderDto.PaymentMethod).Id;
            order.PaymentMethodTypeId = paymentMethods.FirstOrDefault(o => o.Code == orderDto.PaymentMethod).PaymentMethodTypes.FirstOrDefault(o => o.Code == orderDto.PaymentMethodType)?.Id;
            order.ShippingMethodId = shippingMethods.FirstOrDefault(o => o.Code == orderDto.ShippingMethod).Id;
            order.OrderStatusId = orderStatuses.FirstOrDefault(o => o.Code == orderDto.OrderStatus).Id;

            _dbContext.AddOrUpdate(order);
            await _dbContext.SaveChangesAsync();

            return Ok(orderDto);
        }
    }
}
