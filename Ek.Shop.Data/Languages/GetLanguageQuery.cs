using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Base.Data.WorkContexts;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Domain.Languages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Data.Languages
{
    public class GetLanguageQuery : RemoteQuery<GetLanguageCommand, Language>
    {
        private readonly IWorkContext _workContext;

        public GetLanguageQuery(EkShopContext dbContext,
            IWorkContext workContext)
            : base (dbContext)
        {
            _workContext = workContext;
        }

        public override async Task<Language> Query(GetLanguageCommand command)
        {
            var query = DbContext.Languages
                .Include(o => o.LocaleLanguageResources)
                .AsQueryable();

            if (command.LanguageId > 0)
            {
                query = query.Where(o => o.Id == command.LanguageId);
            }
            else
            {
                query = query.Where(o => o.Id == _workContext.WorkingLanguageId);
            }

            return await query.FirstOrDefaultAsync();
        }
    }
}
