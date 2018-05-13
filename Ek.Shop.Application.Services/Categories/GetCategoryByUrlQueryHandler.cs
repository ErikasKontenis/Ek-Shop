using Ek.Shop.Application.Classifiers;
using Ek.Shop.Application.Routes;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Categories
{
    public class GetCategoryByUrlQueryHandler : QueryHandler<GetCategoryByUrlCommand, CategoryDto>
    {
        private readonly IQueryHandler<GetCategoryCommand, CategoryDto> _getCategoryQueryHandler;
        private readonly IQueryHandler<GetRouteByUrlCommand, RouteDto> _getRouteByUrlQueryHandler;

        public GetCategoryByUrlQueryHandler(IQueryHandler<GetCategoryCommand, CategoryDto> getCategoryQueryHandler,
            IQueryHandler<GetRouteByUrlCommand, RouteDto> getRouteByUrlQueryHandler)
        {
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _getRouteByUrlQueryHandler = getRouteByUrlQueryHandler;
        }

        public override async Task<ActionResult<CategoryDto>> Handle(GetCategoryByUrlCommand command)
        {
            var routeDtoResult = await _getRouteByUrlQueryHandler.Handle(new GetRouteByUrlCommand(command.Url, command.LanguageId));
            if (routeDtoResult.Failure)
            {
                return Error(routeDtoResult.ErrorMessages);
            }

            var currentRouteDto = routeDtoResult.Object;
            if (currentRouteDto == null)
                return null;

            var categoryDto = await _getCategoryQueryHandler.Handle(new GetCategoryCommand(currentRouteDto.ItemId.Value, command.LanguageId));
            return categoryDto;
        }
    }
}
