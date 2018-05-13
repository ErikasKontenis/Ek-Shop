using AutoMapper;
using Ek.Shop.Application.Classifiers;
using Ek.Shop.Application.Orders;
using Ek.Shop.Application.Services.AutoMappers;
using Ek.Shop.Application.Services.AutoMappers.Profiles;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Orders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Orders
{
    public class ListOrdersQueryHandler : QueryHandler<ListOrdersCommand, PagedList<OrderDto>>
    {
        private readonly IQueryHandler<ListOrderStatusesCommand, List<OrderStatusDto>> _listOrderStatusesQueryHandler;
        private readonly IQueryHandler<ListShippingMethodsCommand, List<ShippingMethodDto>> _listShippingMethodsQueryHandler;
        private readonly IRemoteQuery<ListOrdersCommand, PagedList<Order>> _listOrdersQuery;

        private IMapper _mapper => AutoMapperFactory
            .CreateMapper<OrderMapperProfile, BasketMapperProfile, ProductMapperProfile>();

        public ListOrdersQueryHandler(IQueryHandler<ListOrderStatusesCommand, List<OrderStatusDto>> listOrderStatusesQueryHandler,
            IQueryHandler<ListShippingMethodsCommand, List<ShippingMethodDto>> listShippingMethodsQueryHandler,
            IRemoteQuery<ListOrdersCommand, PagedList<Order>> listOrdersQuery)
        {
            _listOrderStatusesQueryHandler = listOrderStatusesQueryHandler;
            _listShippingMethodsQueryHandler = listShippingMethodsQueryHandler;
            _listOrdersQuery = listOrdersQuery;
        }

        public override async Task<ActionResult<PagedList<OrderDto>>> Handle(ListOrdersCommand command)
        {
            var orders = await _listOrdersQuery.Query(command);

            var shippingMethodsDtoResult = await _listShippingMethodsQueryHandler.Handle(new ListShippingMethodsCommand());
            if (shippingMethodsDtoResult.Failure)
            {
                return Error(shippingMethodsDtoResult.ErrorMessages);
            }

            var orderStatusesDtoResult = await _listOrderStatusesQueryHandler.Handle(new ListOrderStatusesCommand());
            if (orderStatusesDtoResult.Failure)
            {
                return Error(orderStatusesDtoResult.ErrorMessages);
            }


            // TODO: fix workingLanguageId
            var ordersDto = _mapper.Map(orders, new PagedList<OrderDto>(), opt => opt.Items["WorkingLanguageId"] = 1);
            foreach (var orderDto in ordersDto.Items)
            {
                orderDto.OrderStatus = orderStatusesDtoResult.Object.FirstOrDefault(o => o.Value.ToString() == orderDto.OrderStatus).Text;
                orderDto.ShippingMethod = shippingMethodsDtoResult.Object.FirstOrDefault(o => o.Value.ToString() == orderDto.ShippingMethod).Text;
            }

            return Ok(ordersDto);
        }
    }
}
