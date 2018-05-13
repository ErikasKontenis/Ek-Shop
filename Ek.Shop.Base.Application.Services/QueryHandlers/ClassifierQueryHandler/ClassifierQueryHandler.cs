using Ek.Shop.Application.Abstractions;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Base.Application.Services.QueryHandlers.ClassifierQueryHandler
{
    public abstract class ClassifierQueryHandler<TCommand, TClassifier, TResult> : QueryHandler<TCommand, List<TResult>>, IQueryHandler<TCommand, List<TResult>> where TCommand : ICommand where TResult : ClassifierDto, new() where TClassifier : Classifier
    {
        protected readonly IClassifierBus<TCommand, TClassifier> Bus;

        public ClassifierQueryHandler(IClassifierBus<TCommand, TClassifier> bus)
        {
            Bus = bus;
        }

        public override async Task<ActionResult<List<TResult>>> Handle(TCommand command)
        {
            var classifiers = await Bus.ListClassifiersQuery.Query(command);
            if (classifiers == null)
            {
                return Error();
            }

            var phrases = await Bus.ListPhrasesByNameQuery.Query(new ListPhrasesByNameCommand(classifiers.Select(o => o.Code)));
            var classifiersDto = new List<TResult>();
            foreach (var classifier in classifiers)
            {
                var classifierDto = new TResult()
                {
                    Text = phrases.FirstOrDefault(o => o.Code == classifier.Code)?.Value ?? classifier.Code,
                    Value = classifier.Id
                };

                if (!string.IsNullOrWhiteSpace(classifier.Code))
                {
                    classifierDto.Value = classifier.Code;
                }

                classifiersDto.Add(classifierDto);
            }

            return Ok(classifiersDto);
        }
    }
}
