using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Domain;
using Ek.Shop.Domain.Phrases;
using System.Collections.Generic;

namespace Ek.Shop.Base.Application.Services.QueryHandlers.ClassifierQueryHandler
{
    public interface IClassifierBus<TCommand, TClassifier> where TCommand : ICommand where TClassifier : Classifier
    {
        IRemoteQuery<TCommand, List<TClassifier>> ListClassifiersQuery { get; }

        IRemoteQuery<ListPhrasesByNameCommand, List<Phrase>> ListPhrasesByNameQuery { get; }
    }
}
