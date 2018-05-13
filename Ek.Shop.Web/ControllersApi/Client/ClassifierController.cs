using Ek.Shop.Application.Classifiers;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ek.Shop.Web.ControllersApi.Client
{
    [ResponseCache(CacheProfileName = "ResponseCachingDefault")]
    [Route("api/[controller]")]
    public class ClassifierController : ClientController
    {
        public ClassifierController(IBus bus)
            : base(bus)
        { }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetPhrasesByTerm(string term, string characteristic)
        {
            var phrasesDtoResult = await QueryProcessor.GetQueryHandler<ListPhrasesByTermCommand, List<PhraseDto>>(new ListPhrasesByTermCommand(term, characteristic));
            if (phrasesDtoResult.Failure)
            {
                return BadRequest(phrasesDtoResult.ErrorMessages);
            }

            var phrasesDto = phrasesDtoResult.Object;
            return Ok(phrasesDto);
        }
    }
}
