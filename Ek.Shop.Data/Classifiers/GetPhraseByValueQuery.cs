using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Domain.Phrases;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Data.Classifiers
{
    public class GetPhraseByValueQuery : RemoteQuery<GetPhraseByValueCommand, Phrase>
    {
        public GetPhraseByValueQuery(EkShopContext dbContext)
            : base (dbContext)
        { }

        public override async Task<Phrase> Query(GetPhraseByValueCommand command)
        {
            var query = DbContext.Phrases
                    .Where(o => o.Value == command.Value);

            return await query.FirstOrDefaultAsync();
        }
    }
}
