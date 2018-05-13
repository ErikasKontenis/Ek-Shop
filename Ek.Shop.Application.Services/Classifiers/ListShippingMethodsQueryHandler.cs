using Ek.Shop.Application.Classifiers;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Contracts.Extensions;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Phrases;
using Ek.Shop.Domain.Transactions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Classifiers
{
    public class ListShippingMethodsQueryHandler : QueryHandler<ListShippingMethodsCommand, List<ShippingMethodDto>>
    {
        private readonly IRemoteQuery<ListShippingMethodsCommand, List<ShippingMethod>> _listShippingMethodsQuery;
        private readonly IRemoteQuery<ListPhrasesByNameCommand, List<Phrase>> _listPhrasesByNameQuery;

        public ListShippingMethodsQueryHandler(IRemoteQuery<ListShippingMethodsCommand, List<ShippingMethod>> listShippingMethodsQuery,
            IRemoteQuery<ListPhrasesByNameCommand, List<Phrase>> listPhrasesByNameQuery)
        {
            _listShippingMethodsQuery = listShippingMethodsQuery;
            _listPhrasesByNameQuery = listPhrasesByNameQuery;
        }

        public override async Task<ActionResult<List<ShippingMethodDto>>> Handle(ListShippingMethodsCommand command)
        {
            var shippingMethods = await _listShippingMethodsQuery.Query(command);
            if (shippingMethods == null)
            {
                return Error();
            }

            var phrases = await _listPhrasesByNameQuery.Query(new ListPhrasesByNameCommand(shippingMethods.Select(o => o.Code)));
            var shippingMethodsDto = new List<ShippingMethodDto>();
            foreach (var shippingMethod in shippingMethods)
            {
                shippingMethodsDto.Add(new ShippingMethodDto()
                {
                    Price = shippingMethod.Price,
                    Text = (phrases.FirstOrDefault(o => o.Code == shippingMethod.Code)?.Value ?? shippingMethod.Code) + $" + {shippingMethod.Price.ToCurrencyString()}€",
                    Value = shippingMethod.Code
                });
            }

            return Ok(shippingMethodsDto);
        }
    }
}
