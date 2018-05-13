using Ek.Shop.Application.Baskets;
using Ek.Shop.Application.Classifiers;
using Ek.Shop.Application.Orders;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Orders
{
    public class GetOrderDataQueryHandler : QueryHandler<GetOrderDataCommand, OrderDataDto>
    {
        private readonly IQueryHandler<ListPaymentMethodsCommand, List<PaymentMethodDto>> _listPaymentMethodsQueryHandler;
        private readonly IQueryHandler<ListShippingMethodsCommand, List<ShippingMethodDto>> _listShippingMethodsQueryHandler;
        private readonly IQueryHandler<CreateOrGetUnconfirmedBasketCommand, BasketDto> _createOrGetUnconfirmedBasketQueryHandler;

        public GetOrderDataQueryHandler(IQueryHandler<ListPaymentMethodsCommand, List<PaymentMethodDto>> listPaymentMethodsQueryHandler,
            IQueryHandler<ListShippingMethodsCommand, List<ShippingMethodDto>> listShippingMethodsQueryHandler,
            IQueryHandler<CreateOrGetUnconfirmedBasketCommand, BasketDto> createOrGetUnconfirmedBasketQueryHandler)
        {
            _listPaymentMethodsQueryHandler = listPaymentMethodsQueryHandler;
            _listShippingMethodsQueryHandler = listShippingMethodsQueryHandler;
            _createOrGetUnconfirmedBasketQueryHandler = createOrGetUnconfirmedBasketQueryHandler;
        }

        public override async Task<ActionResult<OrderDataDto>> Handle(GetOrderDataCommand command)
        {
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

            var basketDtoResult = await _createOrGetUnconfirmedBasketQueryHandler.Handle(new CreateOrGetUnconfirmedBasketCommand());
            if (basketDtoResult.Failure)
            {
                return Error(basketDtoResult.ErrorMessages);
            }

            var orderDataDto = new OrderDataDto();
            var paymentMethodsDto = paymentMethodsDtoResult.Object;
            var shippingMethodsDto = shippingMethodsDtoResult.Object;
            var basketDto = basketDtoResult.Object;

            orderDataDto.PaymentMethods = paymentMethodsDto;
            orderDataDto.ShippingMethods = shippingMethodsDto;
            orderDataDto.TotalBasketPrice = basketDto.GetTotalPrice();
            orderDataDto.TotalBasketVat = decimal.Round(basketDto.GetTotalPrice() * 21 / 121, 2, MidpointRounding.AwayFromZero);

            return Ok(orderDataDto);
        }
    }
}
