using Ek.Shop.Application.Services.Infrastructure;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Categories
{
    public class MergeCharacteristicQueryHandler : QueryHandler<GetCategoryCommand, CharacteristicBase>
    {

        public MergeCharacteristicQueryHandler()
        {

        }

        public override async Task<ActionResult<List<CharacteristicBase>>> Handle(GetCategoryCommand command)
        {
            var pagedCategories = await _listCategoriesQuery.Query(command);
            var pagedNavigationsDto = _mapper.Map(pagedCategories, new PagedList<CategoryNavigationDto>());

            return Ok(pagedNavigationsDto);
        }
    }
}
