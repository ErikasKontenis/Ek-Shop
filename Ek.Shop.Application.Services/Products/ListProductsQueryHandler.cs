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
    public class ListProductsQueryHandler : QueryHandler<ListProductsCommand, PagedList<ProductDto>>
    {
        private readonly IRemoteQuery<ListProductsCommand, PagedList<Product>> _listProductsQuery;

        private IMapper _mapper => AutoMapperFactory
            .CreateMapper<ProductMapperProfile, ImageMapperProfile>();

        public ListProductsQueryHandler(IRemoteQuery<ListProductsCommand, PagedList<Product>> listProductsQuery)
        {
            _listProductsQuery = listProductsQuery;
        }

        public override async Task<ActionResult<PagedList<ProductDto>>> Handle(ListProductsCommand command)
        {
            var products = await _listProductsQuery.Query(command);

            var productsDto = _mapper.Map(products, new PagedList<ProductDto>(), opt => opt.Items["WorkingLanguageId"] = command.LanguageId);

            return Ok(productsDto);
        }
    }
}
