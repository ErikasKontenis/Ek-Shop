using Ek.Shop.Base.Application.Services.QueryHandlers.ClassifierQueryHandler;
using Ek.Shop.Base.Data.Queries.RemoteQuery;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Domain.Phrases;
using System.Collections.Generic;

namespace Ek.Shop.Application.Services.Infrastructure
{
    public class ClassifierBus : IClassifierBus
    {
        public IRemoteQuery<ListPhrasesByNameCommand, List<Phrase>> ListPhrasesByNameQuery { get; }

        public ClassifierBus(IRemoteQuery<ListPhrasesByNameCommand, List<Phrase>> listPhrasesByNameQuery)
        {
            ListPhrasesByNameQuery = listPhrasesByNameQuery;
        }
    }
}
