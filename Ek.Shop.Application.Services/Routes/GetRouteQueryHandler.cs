using AutoMapper;
using Ek.Shop.Application.Routes;
using Ek.Shop.Application.Services.AutoMappers;
using Ek.Shop.Application.Services.AutoMappers.Profiles;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Routes;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Routes
{
    public class GetRouteQueryHandler : QueryHandler<GetRouteCommand, RouteDto>
    {
        private readonly IRemoteQuery<GetRouteCommand, Route> _getRouteQuery;

        private IMapper _mapper => AutoMapperFactory.CreateMapper<RouteMapperProfile>();

        public GetRouteQueryHandler(IRemoteQuery<GetRouteCommand, Route> getRouteQuery)
        {
            _getRouteQuery = getRouteQuery;
        }

        public override async Task<ActionResult<RouteDto>> Handle(GetRouteCommand command)
        {
            var route = await _getRouteQuery.Query(command);
            if (route == null)
            {
                return Error();
            }

            var routeDto = _mapper.Map(route, new RouteDto());
            return Ok(routeDto);
        }
    }
}
