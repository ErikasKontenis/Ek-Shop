using AutoMapper;
using Ek.Shop.Application.Classifiers;
using Ek.Shop.Application.Services.AutoMappers;
using Ek.Shop.Application.Services.AutoMappers.Profiles;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Phrases;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Classifiers
{
    public class ListPhrasesByTermQueryHandler : QueryHandler<ListPhrasesByTermCommand, List<PhraseDto>>
    {
        private readonly IRemoteQuery<ListPhrasesByTermCommand, List<Phrase>> _listPhrasesQuery;

        private IMapper _mapper => AutoMapperFactory.CreateMapper<ClassifierMapperProfile>();

        public ListPhrasesByTermQueryHandler(IRemoteQuery<ListPhrasesByTermCommand, List<Phrase>> listPhrasesQuery)
        {
            _listPhrasesQuery = listPhrasesQuery;
        }

        public override async Task<ActionResult<List<PhraseDto>>> Handle(ListPhrasesByTermCommand command)
        {
            var phrases = await _listPhrasesQuery.Query(command);
            if (phrases == null)
            {
                return Error();
            }

            var phrasesDto = _mapper.Map(phrases, new List<PhraseDto>());

            return Ok(phrasesDto);
        }
    }
}
