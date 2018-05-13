using Ek.Shop.Application.Orders;
using Ek.Shop.Application.Profiles;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.WorkContexts;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Profiles
{
    public class GetProfileQueryHandler : QueryHandler<GetProfileCommand, ProfileDto>
    {
        private readonly IQueryHandler<ListOrdersCommand, PagedList<OrderDto>> _listOrdersQueryHandler;
        private readonly IWorkContext _workContext;

        public GetProfileQueryHandler(IQueryHandler<ListOrdersCommand, PagedList<OrderDto>> listOrdersQueryHandler,
            IWorkContext workContext)
        {
            _listOrdersQueryHandler = listOrdersQueryHandler;
            _workContext = workContext;
        }

        public override async Task<ActionResult<ProfileDto>> Handle(GetProfileCommand command)
        {
            var workingUser = await _workContext.GetWorkingUser();
            if (workingUser == null)
            {
                return Error();
            }

            var ordersDtoResult = await _listOrdersQueryHandler.Handle(new ListOrdersCommand(workingUser.Id));
            if (ordersDtoResult.Failure)
            {
                return Error(ordersDtoResult.ErrorMessages);
            }

            var profileDto = new ProfileDto();
            var ordersDto = ordersDtoResult.Object;

            profileDto.Orders = ordersDto;

            return Ok(profileDto);
        }
    }
}
