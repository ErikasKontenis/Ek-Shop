using AutoMapper;
using Ek.Shop.Application.Classifiers;
using Ek.Shop.Application.Services.AutoMappers;
using Ek.Shop.Application.Services.AutoMappers.Profiles;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Base.Data.WorkContexts;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Categories;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Categories
{
    public class GetCategoryQueryHandler : QueryHandler<GetCategoryCommand, CategoryDto>
    {
        private readonly IRemoteQuery<GetCategoryCommand, Category> _getCategoryQuery;
        private readonly IWorkContext _workContext;

        private IMapper _mapper => AutoMapperFactory
            .CreateMapper<CategoryMapperProfile, CategoryBreadcrumbMapperProfile, ImageMapperProfile>();

        public GetCategoryQueryHandler(IRemoteQuery<GetCategoryCommand, Category> getCategoryQuery,
            IWorkContext workContext)
        {
            _getCategoryQuery = getCategoryQuery;
            _workContext = workContext;
        }

        public override async Task<ActionResult<CategoryDto>> Handle(GetCategoryCommand command)
        {
            var category = await _getCategoryQuery.Query(command);
            if (category == null)
            {
                return Error();
            }

            var categoryDto = _mapper.Map(category, new CategoryDto(), opt => opt.Items["WorkingLanguageId"] = command.LanguageId);

            return Ok(categoryDto);
        }
    }
}
