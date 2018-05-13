using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Domain;
using Ek.Shop.Domain.Phrases;
using System.Collections.Generic;

namespace Ek.Shop.Base.Application.Services.QueryHandlers.ClassifierQueryHandler
{
    public class ClassifierBus<TCommand, TClassifier> : IClassifierBus<TCommand, TClassifier> where TCommand : ICommand where TClassifier : Classifier
    {
        public IRemoteQuery<TCommand, List<TClassifier>> ListClassifiersQuery { get; }

        public IRemoteQuery<ListPhrasesByNameCommand, List<Phrase>> ListPhrasesByNameQuery { get; }

        public ClassifierBus(IRemoteQuery<TCommand, List<TClassifier>> listClassifiersQuery,
            IRemoteQuery<ListPhrasesByNameCommand, List<Phrase>> listPhrasesByNameQuery)
        {
            ListClassifiersQuery = listClassifiersQuery;
            ListPhrasesByNameQuery = listPhrasesByNameQuery;
        }
    }
}
