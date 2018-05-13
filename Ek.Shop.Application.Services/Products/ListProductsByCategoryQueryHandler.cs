using AutoMapper;
using Ek.Shop.Application.Products;
using Ek.Shop.Application.Services.AutoMappers;
using Ek.Shop.Application.Services.AutoMappers.Profiles;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Products;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Products
{
    public class ListProductsByCategoryQueryHandler : QueryHandler<ListProductsByCategoryCommand, PagedList<ProductDto>>
    {
        private readonly IRemoteQuery<ListProductsByCategoryCommand, PagedList<Product>> _listProductsByCategoryQuery;

        private IMapper _mapper => AutoMapperFactory
            .CreateMapper<ProductMapperProfile, ImageMapperProfile>();

        public ListProductsByCategoryQueryHandler(IRemoteQuery<ListProductsByCategoryCommand, PagedList<Product>> listProductsByCategoryQuery)
        {
            _listProductsByCategoryQuery = listProductsByCategoryQuery;
        }

        public override async Task<ActionResult<PagedList<ProductDto>>> Handle(ListProductsByCategoryCommand command)
        {
            var products = await _listProductsByCategoryQuery.Query(command);

            var productsDto = _mapper.Map(products, new PagedList<ProductDto>(), opt => opt.Items["WorkingLanguageId"] = command.LanguageId);
           
            return Ok(productsDto);
        }
    }
}
