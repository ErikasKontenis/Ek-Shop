using AutoMapper;
using Ek.Shop.Application.Abstractions;
using Ek.Shop.Application.Services.AutoMappers;
using Ek.Shop.Application.Services.AutoMappers.Profiles;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.SystemSettings;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.SystemSettings
{
    public class GetSystemSettingQueryHandler : QueryHandler<GetSystemSettingCommand, OptionDto>
    {
        private readonly IRemoteQuery<GetSystemSettingCommand, SystemSetting> _getSystemSettingQuery;

        private IMapper _mapper => AutoMapperFactory.CreateMapper<CommonMapperProfile<SystemSetting, OptionDto>>();

        public GetSystemSettingQueryHandler(IRemoteQuery<GetSystemSettingCommand, SystemSetting> getSystemSettingQuery)
        {
            _getSystemSettingQuery = getSystemSettingQuery;
        }

        public override async Task<ActionResult<OptionDto>> Handle(GetSystemSettingCommand command)
        {
            var systemSettingQuery = await _getSystemSettingQuery.Query(command);
            if (systemSettingQuery == null)
            {
                ActionResult<OptionDto>.Error();
            }

            var inputFormDto = _mapper.Map<OptionDto>(systemSettingQuery);
            return ActionResult<OptionDto>.Ok(inputFormDto);
        }
    }
}
