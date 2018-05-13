using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Domain.SystemSettings;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Data.SystemSettings
{
    public class GetSystemSettingQuery : RemoteQuery<GetSystemSettingCommand, SystemSetting>
    {
        public GetSystemSettingQuery(EkShopContext dbContext)
            : base (dbContext)
        { }

        public override async Task<SystemSetting> Query(GetSystemSettingCommand command)
        {
            var query = DbContext.SystemSettings;

            return await query.Where(o => o.Code == command.SystemSetting).FirstOrDefaultAsync();
        }
    }
}
