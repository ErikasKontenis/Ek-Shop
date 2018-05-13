using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Base.Data.WorkContexts;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Domain.Phrases;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Data.Classifiers
{
    public class ListPhrasesByNameQuery : RemoteQuery<ListPhrasesByNameCommand, List<Phrase>>
    {
        private readonly IWorkContext _workContext;

        public ListPhrasesByNameQuery(EkShopContext dbContext,
            IWorkContext workContext)
            : base (dbContext)
        {
            _workContext = workContext;
        }

        public override async Task<List<Phrase>> Query(ListPhrasesByNameCommand command)
        {
            var query = DbContext.Phrases
                    .Where(o => command.Names.Contains(o.Code) && o.LanguageId == _workContext.WorkingLanguageId);

            return await query.ToListAsync();
        }

    }
}
