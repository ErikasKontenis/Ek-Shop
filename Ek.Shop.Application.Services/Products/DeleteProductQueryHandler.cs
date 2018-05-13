using Ek.Shop.Application.Products;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Products;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Products
{
    public class DeleteProductQueryHandler : QueryHandler<DeleteProductCommand, ProductDto>
    {
        private readonly IRemoteQuery<DeleteProductCommand, Product> _deleteProductQuery;

        public DeleteProductQueryHandler(IRemoteQuery<DeleteProductCommand, Product> getProductQuery)
        {
            _deleteProductQuery = getProductQuery;
        }

        public override async Task<ActionResult<ProductDto>> Handle(DeleteProductCommand command)
        {
            var product = await _deleteProductQuery.Query(command);
            if (product == null)
            {
                // Nothing to delete
                return Error();
            }

            return Ok(null);
        }
    }
}
