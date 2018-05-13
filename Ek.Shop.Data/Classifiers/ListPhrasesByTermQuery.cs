using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Domain.Phrases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Data.Classifiers
{
    public class ListPhrasesByTermQuery : RemoteQuery<ListPhrasesByTermCommand, List<Phrase>>
    {
        public ListPhrasesByTermQuery(EkShopContext dbContext)
            : base (dbContext)
        { }

        public override async Task<List<Phrase>> Query(ListPhrasesByTermCommand command)
        {
            var query = DbContext.Phrases
                    .Where(o => o.Value.StartsWith(command.Term, StringComparison.CurrentCultureIgnoreCase))
                    .Select(o => o.Value)
                    .Distinct()
                    .Take(5);

            var result = await query.ToListAsync();
            return result.Select(o => new Phrase() { Value = o }).ToList();
        }
    }
}
