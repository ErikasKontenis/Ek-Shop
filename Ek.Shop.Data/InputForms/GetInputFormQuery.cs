using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.InputForms;
using Ek.Shop.Domain.SystemSettings;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Data.InputForms
{
    public class GetInputFormQuery : RemoteQuery<GetInputFormCommand, InputForm>
    {
        private readonly IRemoteQuery<GetSystemSettingCommand, SystemSetting> _getSystemSettingQuery;

        public GetInputFormQuery(EkShopContext dbContext, IRemoteQuery<GetSystemSettingCommand, SystemSetting> getSystemSettingQuery)
            : base (dbContext)
        {
            _getSystemSettingQuery = getSystemSettingQuery;
        }

        public override async Task<InputForm> Query(GetInputFormCommand command)
        {
            var query = DbContext.InputForms
                    .Include(o => o.InputFormOptions);

            if (string.IsNullOrEmpty(command.InputFormName))
            {
                var activeInputForm = await _getSystemSettingQuery.Query(new GetSystemSettingCommand(SystemSettingOptions.ActiveInputForm.Name));
                command.InputFormName = activeInputForm.Value;
            }

            return await query.Where(o => o.Code == command.InputFormName).FirstOrDefaultAsync();
        }
    }
}
