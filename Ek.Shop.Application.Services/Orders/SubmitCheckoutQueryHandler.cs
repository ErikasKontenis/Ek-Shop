using AutoMapper;
using Ek.Shop.Application.Checkouts;
using Ek.Shop.Application.Classifiers;
using Ek.Shop.Application.Extensions;
using Ek.Shop.Application.Services.AutoMappers;
using Ek.Shop.Application.Services.AutoMappers.Profiles;
using Ek.Shop.Application.Services.Infrastructure;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Contracts.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Core.Models;
using Ek.Shop.Data.Infrastructure;
using Ek.Shop.Data.Models;
using Ek.Shop.Domain.Baskets;
using Ek.Shop.Domain.Orders;
using Ek.Shop.Domain.PaymentMethods;
using Ek.Shop.Domain.Transactions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Checkouts
{
    public class SubmitCheckoutQueryHandler : QueryHandler<SubmitCheckoutCommand, SubmitCheckoutDto>
    {
        private readonly IQueryHandler<GetCategoryByUrlCommand, CategoryDto> _getCategoryByUrlQueryHandler;
        private readonly IRemoteQuery<CreateOrGetUnconfirmedBasketCommand, Basket> _createOrGetUnconfirmedBasketQuery;
        private readonly IRemoteQuery<ListPaymentMethodsCommand, List<PaymentMethod>> _listPaymentMethodsQuery;
        private readonly IRemoteQuery<ListShippingMethodsCommand, List<ShippingMethod>> _listShippingMethodsQuery;
        private readonly EkShopContext _dbContext;

        private IMapper _mapper => AutoMapperFactory
            .CreateMapper<OrderMapperProfile>();

        public SubmitCheckoutQueryHandler(IQueryHandler<GetCategoryByUrlCommand, CategoryDto> getCategoryByUrlQueryHandler,
            IRemoteQuery<CreateOrGetUnconfirmedBasketCommand, Basket> createOrGetUnconfirmedBasketQuery,
            IRemoteQuery<ListPaymentMethodsCommand, List<PaymentMethod>> listPaymentMethodsQuery,
            IRemoteQuery<ListShippingMethodsCommand, List<ShippingMethod>> listShippingMethodsQuery,
            EkShopContext dbContext)
        {
            _getCategoryByUrlQueryHandler = getCategoryByUrlQueryHandler;
            _createOrGetUnconfirmedBasketQuery = createOrGetUnconfirmedBasketQuery;
            _listPaymentMethodsQuery = listPaymentMethodsQuery;
            _listShippingMethodsQuery = listShippingMethodsQuery;
            _dbContext = dbContext;
        }

        public override async Task<ActionResult<SubmitCheckoutDto>> Handle(SubmitCheckoutCommand command)
        {
            var checkoutCategoryDtoResult = await _getCategoryByUrlQueryHandler.Handle(new GetCategoryByUrlCommand(command.RouteUrl));
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
            var order = new Order();
            

            _mapper.Map(command.Order, new Order());
            order.UserId = basket.UserId;
            order.BasketId = basket.Id;
            order.PaymentMethodId = paymentMethods.FirstOrDefault(o => o.Name == orderDto.PaymentMethod).Id;
            order.PaymentMethodTypeId = paymentMethods.FirstOrDefault(o => o.Name == orderDto.PaymentMethod).PaymentMethodTypes.FirstOrDefault(o => o.Name == orderDto.PaymentMethodType)?.Id;
            order.ShippingMethodId = shippingMethods.FirstOrDefault(o => o.Name == orderDto.ShippingMethod).Id;

            _dbContext.ActionByEntityState(basket, EntityState.Modified);
            _dbContext.ActionByEntityState(order, EntityState.Added);
            await _dbContext.SaveChangesAsync();

            return Ok(new SubmitCheckoutDto());
        }
    }
}
