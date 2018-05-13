using AutoMapper;
using Ek.Shop.Application.Classifiers;
using Ek.Shop.Application.Services.AutoMappers;
using Ek.Shop.Application.Services.AutoMappers.Profiles;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Categories;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Categories
{
    public class ListCategoriesQueryHandler : QueryHandler<ListCategoriesCommand, PagedList<CategoryDto>>
    {
        private readonly IRemoteQuery<ListCategoriesCommand, PagedList<Category>> _listCategoriesQuery;

        private IMapper _mapper => AutoMapperFactory
            .CreateMapper<CategoryMapperProfile, ImageMapperProfile>();

        public ListCategoriesQueryHandler(IRemoteQuery<ListCategoriesCommand, PagedList<Category>> listCategoriesQuery)
        {
            _listCategoriesQuery = listCategoriesQuery;
        }

        public override async Task<ActionResult<PagedList<CategoryDto>>> Handle(ListCategoriesCommand command)
        {
            var pagedCategories = await _listCategoriesQuery.Query(command);
            var pagedCategoriesDto = _mapper.Map(pagedCategories, new PagedList<CategoryDto>(), opt => opt.Items["WorkingLanguageId"] = command.LanguageId);
            return Ok(pagedCategoriesDto.Items.ToPagedList(command));
        }
    }
}
