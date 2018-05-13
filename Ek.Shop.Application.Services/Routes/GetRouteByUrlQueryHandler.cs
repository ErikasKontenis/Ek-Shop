using AutoMapper;
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
    public class GetRouteByUrlQueryHandler : QueryHandler<GetRouteByUrlCommand, RouteDto>
    {
        private readonly IRemoteQuery<ListRoutesCommand, List<Route>> _listRoutesQuery;
        private readonly IRemoteQuery<GetCategoryCommand, Category> _getCategoryQuery;

        private IMapper _mapper => AutoMapperFactory.CreateMapper<RouteMapperProfile>();

        public GetRouteByUrlQueryHandler(IRemoteQuery<ListRoutesCommand, List<Route>> listRoutesQuery,
            IRemoteQuery<GetCategoryCommand, Category> getCategoryQuery)
        {
            _listRoutesQuery = listRoutesQuery;
            _getCategoryQuery = getCategoryQuery;
        }

        public override async Task<ActionResult<RouteDto>> Handle(GetRouteByUrlCommand command)
        {
            command.Url = command.Url?.TrimStart('/') ?? "";

            var lastUrlChain = command.Url.Split('/').ToList().Last();
            var routes = await _listRoutesQuery.Query(new ListRoutesCommand(lastUrlChain));
            foreach (var route in routes)
            {
                if (route.Product != null && route.Product.Id > 0)
                {
                    return Ok(_mapper.Map(route, new RouteDto()));
                }
                else if (route.Category != null && route.Category.Id > 0)
                {
                    var category = await _getCategoryQuery.Query(new GetCategoryCommand(route.Category.Id, command.LanguageId));
                    if (category.GetCategoryChainedNavigation() == command.Url)
                    {
                        return Ok(_mapper.Map(route, new RouteDto()));
                    }
                }
            }
            
            return Ok(null);
        }
    }
}
