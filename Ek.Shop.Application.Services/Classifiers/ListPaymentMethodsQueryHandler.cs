using Ek.Shop.Application.Classifiers;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.PaymentMethods;
using Ek.Shop.Domain.Phrases;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Classifiers
{
    public class ListPaymentMethodsQueryHandler : QueryHandler<ListPaymentMethodsCommand, List<PaymentMethodDto>>
    {
        private readonly IRemoteQuery<ListPaymentMethodsCommand, List<PaymentMethod>> _listPaymentMethodsQuery;
        private readonly IRemoteQuery<ListPhrasesByNameCommand, List<Phrase>> _listPhrasesByNameQuery;

        public ListPaymentMethodsQueryHandler(IRemoteQuery<ListPaymentMethodsCommand, List<PaymentMethod>> listPaymentMethodsQuery,
            IRemoteQuery<ListPhrasesByNameCommand, List<Phrase>> listPhrasesByNameQuery)
        {
            _listPaymentMethodsQuery = listPaymentMethodsQuery;
            _listPhrasesByNameQuery = listPhrasesByNameQuery;
        }

        public override async Task<ActionResult<List<PaymentMethodDto>>> Handle(ListPaymentMethodsCommand command)
        {
            var paymentMethods = await _listPaymentMethodsQuery.Query(command);
            if (paymentMethods == null)
            {
                return Error();
            }

            var phrases = await _listPhrasesByNameQuery.Query(new ListPhrasesByNameCommand(paymentMethods.Select(o => o.Code).Concat(paymentMethods.SelectMany(o => o.PaymentMethodTypes.Select(i => i.Code)))));
            var paymentMethodsDto = new List<PaymentMethodDto>();
            foreach (var paymentMethod in paymentMethods)
            {
                var paymentMethodDto = new PaymentMethodDto()
                {
                    Text = phrases.FirstOrDefault(o => o.Code == paymentMethod.Code)?.Value ?? paymentMethod.Code,
                    Value = paymentMethod.Code
                };

                foreach (var paymentMethodType in paymentMethod.PaymentMethodTypes)
                {
                    var paymentMethodTypeDto = new PaymentMethodTypeDto()
                    {
                        Text = phrases.FirstOrDefault(o => o.Code == paymentMethodType.Code)?.Value ?? paymentMethodType.Code,
                        Value = paymentMethodType.Code
                    };

                    paymentMethodDto.PaymentMethodTypes.Add(paymentMethodTypeDto);
                }

                paymentMethodsDto.Add(paymentMethodDto);
            }

            return Ok(paymentMethodsDto);
        }
    }
}
