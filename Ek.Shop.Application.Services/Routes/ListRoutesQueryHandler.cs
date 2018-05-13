using AutoMapper;
using Ek.Shop.Application.Extensions;
using Ek.Shop.Application.Routes;
using Ek.Shop.Application.Services.AutoMappers;
using Ek.Shop.Application.Services.AutoMappers.Profiles;
using Ek.Shop.Application.Services.Categories.Helpers;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Categories;
using Ek.Shop.Domain.Routes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Routes
{
    public class ListRoutesQueryHandler : QueryHandler<ListRoutesCommand, List<RouteDto>>
    {
        private readonly IRemoteQuery<ListRoutesCommand, List<Route>> _listRoutesQuery;

        private IMapper _mapper => AutoMapperFactory.CreateMapper<RouteMapperProfile>();

        public ListRoutesQueryHandler(IRemoteQuery<ListRoutesCommand, List<Route>> listRoutesQuery)
        {
            _listRoutesQuery = listRoutesQuery;
        }

        public override async Task<ActionResult<List<RouteDto>>> Handle(ListRoutesCommand command)
        {
            var routes = await _listRoutesQuery.Query(command);
            if (routes == null)
            {
                return Error();
            }

            var routesDto = new List<RouteDto>();
            var buildedCategoryNavigations = new List<Category>();
            var categoriesForest = routes.Select(o => o.Category).Where(o => o != null).ConvertToForest();
            foreach (var lastCategory in categoriesForest.LastNodes())
            {
                buildedCategoryNavigations.AddRange(lastCategory.BuildCategoryNavigations());
            }

            routesDto.AddRange(_mapper.Map<List<RouteDto>>(buildedCategoryNavigations));
            routesDto.AddRange(_mapper.Map<List<RouteDto>>(routes.Select(o => o.Product)));
            routesDto = routesDto.ToList();

            return Ok(routesDto);
        }
    }
}
