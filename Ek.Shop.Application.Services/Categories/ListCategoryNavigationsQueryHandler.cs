using AutoMapper;
using Ek.Shop.Application.Classifiers;
using Ek.Shop.Application.Services.AutoMappers;
using Ek.Shop.Application.Services.AutoMappers.Profiles;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Categories;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Categories
{
    public class ListCategoryNavigationsQueryHandler : QueryHandler<ListCategoriesCommand, PagedList<CategoryNavigationDto>>
    {
        private readonly IRemoteQuery<ListCategoriesCommand, PagedList<Category>> _listCategoriesQuery;

        private IMapper _mapper => AutoMapperFactory.CreateMapper<CategoryNavigationMapperProfile>();

        public ListCategoryNavigationsQueryHandler(IRemoteQuery<ListCategoriesCommand, PagedList<Category>> listCategoriesQuery)
        {
            _listCategoriesQuery = listCategoriesQuery;
        }

        public override async Task<ActionResult<PagedList<CategoryNavigationDto>>> Handle(ListCategoriesCommand command)
        {
            var pagedCategories = await _listCategoriesQuery.Query(command);
            var pagedNavigationsDto = _mapper.Map(pagedCategories, new PagedList<CategoryNavigationDto>(), opt => opt.Items["WorkingLanguageId"] = command.LanguageId);

            return Ok(pagedNavigationsDto);
        }
    }
}
