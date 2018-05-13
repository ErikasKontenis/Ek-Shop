using AutoMapper;
using Ek.Shop.Application.Routes;
using Ek.Shop.Application.Services.AutoMappers;
using Ek.Shop.Application.Services.AutoMappers.Profiles;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Routes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Routes
{
    public class GetRouteByComponentQueryHandler : QueryHandler<GetRouteByComponentCommand, RouteDto>
    {
        private readonly IRemoteQuery<ListRoutesCommand, List<Route>> _listRoutesQuery;

        private IMapper _mapper => AutoMapperFactory.CreateMapper<RouteMapperProfile>();

        public GetRouteByComponentQueryHandler(IRemoteQuery<ListRoutesCommand, List<Route>> listRoutesQuery)
        {
            _listRoutesQuery = listRoutesQuery;
        }

        public override async Task<ActionResult<RouteDto>> Handle(GetRouteByComponentCommand command)
        {
            // TODO: pagalvoti ar sitas bera reikalingas.
            var routes = await _listRoutesQuery.Query(new ListRoutesCommand());
            return Ok(null);
        }
    }
}
