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
using Ek.Shop.Core.Enums;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Baskets;
using Ek.Shop.Domain.Orders;
using Ek.Shop.Domain.PaymentMethods;
using Ek.Shop.Domain.Transactions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Orders
{
    public class SubmitOrderQueryHandler : QueryHandler<SubmitOrderCommand, OrderDto>
    {
        private readonly IQueryHandler<GetCategoryByUrlCommand, CategoryDto> _getCategoryByUrlQueryHandler;
        private readonly IRemoteQuery<CreateOrGetUnconfirmedBasketCommand, Basket> _createOrGetUnconfirmedBasketQuery;
        private readonly IRemoteQuery<ListPaymentMethodsCommand, List<PaymentMethod>> _listPaymentMethodsQuery;
        private readonly IRemoteQuery<ListShippingMethodsCommand, List<ShippingMethod>> _listShippingMethodsQuery;
        private readonly IRemoteQuery<ListOrderStatusesCommand, List<OrderStatus>> _listOrderStatusesQuery;
        private readonly EkShopContext _dbContext;
        private readonly IWorkContext _workContext;

        private IMapper _mapper => AutoMapperFactory
            .CreateMapper<OrderMapperProfile>();

        public SubmitOrderQueryHandler(IQueryHandler<GetCategoryByUrlCommand, CategoryDto> getCategoryByUrlQueryHandler,
            IRemoteQuery<CreateOrGetUnconfirmedBasketCommand, Basket> createOrGetUnconfirmedBasketQuery,
            IRemoteQuery<ListPaymentMethodsCommand, List<PaymentMethod>> listPaymentMethodsQuery,
            IRemoteQuery<ListShippingMethodsCommand, List<ShippingMethod>> listShippingMethodsQuery,
            IRemoteQuery<ListOrderStatusesCommand, List<OrderStatus>> listOrderStatusesQuery,
            EkShopContext dbContext,
            IWorkContext workContext)
        {
            _getCategoryByUrlQueryHandler = getCategoryByUrlQueryHandler;
            _createOrGetUnconfirmedBasketQuery = createOrGetUnconfirmedBasketQuery;
            _listPaymentMethodsQuery = listPaymentMethodsQuery;
            _listShippingMethodsQuery = listShippingMethodsQuery;
            _listOrderStatusesQuery = listOrderStatusesQuery;
            _dbContext = dbContext;
            _workContext = workContext;
        }

        public override async Task<ActionResult<OrderDto>> Handle(SubmitOrderCommand command)
        {
            var checkoutCategoryDtoResult = await _getCategoryByUrlQueryHandler.Handle(new GetCategoryByUrlCommand(command.RouteUrl, _workContext.WorkingLanguageId));
            if (checkoutCategoryDtoResult.Failure)
            {
                return Error(checkoutCategoryDtoResult.ErrorMessages);
            }

            var checkoutCategoryDto = checkoutCategoryDtoResult.Object;
            var orderDto = command.Order;
            if (orderDto.ShippingMethod == ShippingMethods.Shop)
            {
                checkoutCategoryDto.GetAnyField(nameof(orderDto.Address)).SetCharacteristic(CharacteristicCodes.IsRequired, false);
                checkoutCategoryDto.GetAnyField(nameof(orderDto.City)).SetCharacteristic(CharacteristicCodes.IsRequired, false);
                checkoutCategoryDto.GetAnyField(nameof(orderDto.PostCode)).SetCharacteristic(CharacteristicCodes.IsRequired, false);
            }

            if (orderDto.PaymentMethod == PaymentMethods.Cash)
            {
                checkoutCategoryDto.GetAnyField(nameof(orderDto.PaymentMethodType)).SetCharacteristic(CharacteristicCodes.IsRequired, false);
            }

            var detailErrors = checkoutCategoryDto.Fieldsets.MapToFields(orderDto).ValidateFieldsets();
            if (!detailErrors.IsNullOrEmpty())
            {
                return Error(detailErrors);
            }

            var basket = await _createOrGetUnconfirmedBasketQuery.Query(new CreateOrGetUnconfirmedBasketCommand());
            if (basket.BasketItems.Count <= 0)
            {
                return Error();
            }

            basket.IsConfirmed = true;
            var paymentMethods = await _listPaymentMethodsQuery.Query(new ListPaymentMethodsCommand());
            var shippingMethods = await _listShippingMethodsQuery.Query(new ListShippingMethodsCommand());
            var orderStatuses = await _listOrderStatusesQuery.Query(new ListOrderStatusesCommand());

            var order = new Order();
            _mapper.Map(command.Order, order);
            order.UserId = basket.UserId;
            order.BasketId = basket.Id;
            order.PaymentMethodId = paymentMethods.FirstOrDefault(o => o.Code == orderDto.PaymentMethod).Id;
            order.PaymentMethodTypeId = paymentMethods.FirstOrDefault(o => o.Code == orderDto.PaymentMethod).PaymentMethodTypes.FirstOrDefault(o => o.Code == orderDto.PaymentMethodType)?.Id;
            order.ShippingMethodId = shippingMethods.FirstOrDefault(o => o.Code == orderDto.ShippingMethod).Id;
            order.OrderStatusId = orderStatuses.FirstOrDefault(o => o.Code == OrderStatuses.Unconfirmed).Id;

            _dbContext.AddOrUpdate(basket);
            _dbContext.AddOrUpdate(order);
            await _dbContext.SaveChangesAsync();

            return Ok(orderDto);
        }
    }
}
