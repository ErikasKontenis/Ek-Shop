using AutoMapper;
using Ek.Shop.Application.Orders;
using Ek.Shop.Application.Services.AutoMappers;
using Ek.Shop.Application.Services.AutoMappers.Profiles;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Orders;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Orders
{
    public class GetOrderQueryHandler : QueryHandler<GetOrderCommand, OrderDto>
    {
        private readonly IRemoteQuery<GetOrderCommand, Order> _getOrderQuery;

        private IMapper _mapper => AutoMapperFactory
            .CreateMapper<OrderMapperProfile, BasketMapperProfile, ProductMapperProfile>();

        public GetOrderQueryHandler(IRemoteQuery<GetOrderCommand, Order> getOrderQuery)
        {
            _getOrderQuery = getOrderQuery;
        }

        public override async Task<ActionResult<OrderDto>> Handle(GetOrderCommand command)
        {
            var order = await _getOrderQuery.Query(command);
            if (order == null)
            {
                return Error();
            }

            // TODO: fix WorkingLanguageId
            var orderDto = _mapper.Map(order, new OrderDto(), opt => opt.Items["WorkingLanguageId"] = 1);
            return Ok(orderDto);
        }
    }
}
