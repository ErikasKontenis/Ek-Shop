using AutoMapper;
using Ek.Shop.Application.Products;
using Ek.Shop.Application.Services.AutoMappers;
using Ek.Shop.Application.Services.AutoMappers.Profiles;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Products;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Products
{
    public class GetProductQueryHandler : QueryHandler<GetProductCommand, ProductDto>
    {
        private readonly IRemoteQuery<GetProductCommand, Product> _getProductQuery;

        private IMapper _mapper => AutoMapperFactory
            .CreateMapper<ProductMapperProfile, ImageMapperProfile>();

        public GetProductQueryHandler(IRemoteQuery<GetProductCommand, Product> getProductQuery)
        {
            _getProductQuery = getProductQuery;
        }

        public override async Task<ActionResult<ProductDto>> Handle(GetProductCommand command)
        {
            var product = await _getProductQuery.Query(command);
            if (product == null)
            {
                return Error();
            }

            var productDto = _mapper.Map(product, new ProductDto(), opt => opt.Items["WorkingLanguageId"] = command.LanguageId);
            productDto.Navigations.LastOrDefault().Parameters.Add("IsLastBreadcrumbUrlActive", true);

            return Ok(productDto);
        }
    }
}
