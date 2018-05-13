using AutoMapper;
using Ek.Shop.Application.Languages;
using Ek.Shop.Application.Services.AutoMappers;
using Ek.Shop.Application.Services.AutoMappers.Profiles;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Languages;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Languages
{
    public class GetLanguageQueryHandler : QueryHandler<GetLanguageCommand, LanguageDto>
    {
        private readonly IRemoteQuery<GetLanguageCommand, Language> _getLanguageQuery;

        private IMapper _mapper => AutoMapperFactory.CreateMapper<CommonMapperProfile<Language, LanguageDto>>();

        public GetLanguageQueryHandler(IRemoteQuery<GetLanguageCommand, Language> getLanguageQuery)
        {
            _getLanguageQuery = getLanguageQuery;
        }

        public override async Task<ActionResult<LanguageDto>> Handle(GetLanguageCommand command)
        {
            var language = await _getLanguageQuery.Query(command);
            if (language == null)
            {
                ActionResult<LanguageDto>.Error();
            }

            var languageDto = _mapper.Map<LanguageDto>(language);
            return ActionResult<LanguageDto>.Ok(languageDto);
        }
    }
}
