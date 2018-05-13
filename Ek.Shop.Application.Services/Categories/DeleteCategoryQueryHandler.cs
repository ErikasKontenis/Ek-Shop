using Ek.Shop.Application.Classifiers;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Categories;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Categories
{
    public class DeleteCategoryQueryHandler : QueryHandler<DeleteCategoryCommand, CategoryDto>
    {
        private readonly IRemoteQuery<DeleteCategoryCommand, Category> _deleteCategoryQuery;

        public DeleteCategoryQueryHandler(IRemoteQuery<DeleteCategoryCommand, Category> getCategoryQuery)
        {
            _deleteCategoryQuery = getCategoryQuery;
        }

        public override async Task<ActionResult<CategoryDto>> Handle(DeleteCategoryCommand command)
        {
            var category = await _deleteCategoryQuery.Query(command);
            if (category == null)
            {
                // Nothing to delete
                return Error();
            }

            return Ok(null);
        }
    }
}
