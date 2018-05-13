using Ek.Shop.Application.Classifiers;
using Ek.Shop.Application.Routes;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Categories
{
    public class GetCategoryByComponentQueryHandler : QueryHandler<GetCategoryByComponentCommand, CategoryDto>
    {
        private readonly IQueryHandler<GetCategoryCommand, CategoryDto> _getCategoryQueryHandler;
        private readonly IQueryHandler<GetRouteByComponentCommand, RouteDto> _getRouteByComponentQueryHandler;

        public GetCategoryByComponentQueryHandler(IQueryHandler<GetCategoryCommand, CategoryDto> getCategoryQueryHandler,
            IQueryHandler<GetRouteByComponentCommand, RouteDto> getRouteByComponentQueryHandler)
        {
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _getRouteByComponentQueryHandler = getRouteByComponentQueryHandler;
        }

        public override async Task<ActionResult<CategoryDto>> Handle(GetCategoryByComponentCommand command)
        {
            var routeDtoResult = await _getRouteByComponentQueryHandler.Handle(new GetRouteByComponentCommand(command.Component));
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
