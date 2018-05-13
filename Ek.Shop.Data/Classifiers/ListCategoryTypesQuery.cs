using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Domain.Categories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ek.Shop.Data.Classifiers
{
    public class ListCategoryTypesQuery : RemoteQuery<ListCategoryTypesCommand, List<CategoryType>>
    {
        public ListCategoryTypesQuery(EkShopContext dbContext)
            : base(dbContext)
        { }

        public override async Task<List<CategoryType>> Query(ListCategoryTypesCommand command)
        {
            var query = DbContext.CategoryTypes;

            return await query.ToListAsync();
        }
    }
}
