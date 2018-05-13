using Ek.Shop.Application.Classifiers;
using Ek.Shop.Application.Orders;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Orders
{
    public class GetEditOrderDataQueryHandler : QueryHandler<GetEditOrderDataCommand, EditOrderDataDto>
    {
        private readonly IQueryHandler<ListOrderStatusesCommand, List<OrderStatusDto>> _listOrderStatusesQueryHandler;
        private readonly IQueryHandler<ListPaymentMethodsCommand, List<PaymentMethodDto>> _listPaymentMethodsQueryHandler;
        private readonly IQueryHandler<ListShippingMethodsCommand, List<ShippingMethodDto>> _listShippingMethodsQueryHandler;
        private readonly IQueryHandler<GetOrderCommand, OrderDto> _getOrderQueryHandler;

        public GetEditOrderDataQueryHandler(IQueryHandler<ListOrderStatusesCommand, List<OrderStatusDto>> listOrderStatusesQueryHandler,
            IQueryHandler<ListPaymentMethodsCommand, List<PaymentMethodDto>> listPaymentMethodsQueryHandler,
            IQueryHandler<ListShippingMethodsCommand, List<ShippingMethodDto>> listShippingMethodsQueryHandler,
            IQueryHandler<GetOrderCommand, OrderDto> getOrderQueryHandler)
        {
            _listOrderStatusesQueryHandler = listOrderStatusesQueryHandler;
            _listPaymentMethodsQueryHandler = listPaymentMethodsQueryHandler;
            _listShippingMethodsQueryHandler = listShippingMethodsQueryHandler;
            _getOrderQueryHandler = getOrderQueryHandler;
        }

        public override async Task<ActionResult<EditOrderDataDto>> Handle(GetEditOrderDataCommand command)
        {
            var orderStatusesDtoResult = await _listOrderStatusesQueryHandler.Handle(new ListOrderStatusesCommand());
            if (orderStatusesDtoResult.Failure)
            {
                return Error(orderStatusesDtoResult.ErrorMessages);
            }

            var paymentMethodsDtoResult = await _listPaymentMethodsQueryHandler.Handle(new ListPaymentMethodsCommand());
            if (paymentMethodsDtoResult.Failure)
            {
                return Error(paymentMethodsDtoResult.ErrorMessages);
            }

            var shippingMethodsDtoResult = await _listShippingMethodsQueryHandler.Handle(new ListShippingMethodsCommand());
            if (shippingMethodsDtoResult.Failure)
            {
                return Error(shippingMethodsDtoResult.ErrorMessages);
            }

            var orderDtoResult = await _getOrderQueryHandler.Handle(new GetOrderCommand(command.OrderId));
            if (orderDtoResult.Failure)
            {
                return Error(orderDtoResult.ErrorMessages);
            }

            var editOrderDataDto = new EditOrderDataDto();
            var orderDto = orderDtoResult.Object;

            editOrderDataDto.Order = orderDto;
            editOrderDataDto.OrderStatuses = orderStatusesDtoResult.Object;
            editOrderDataDto.PaymentMethods = paymentMethodsDtoResult.Object;
            editOrderDataDto.ShippingMethods = shippingMethodsDtoResult.Object;

            return Ok(editOrderDataDto);
        }
    }
}
