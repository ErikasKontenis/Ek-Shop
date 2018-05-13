using AutoMapper;
using Ek.Shop.Application.InputForms;
using Ek.Shop.Application.Services.AutoMappers;
using Ek.Shop.Application.Services.AutoMappers.Profiles;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.InputForms;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.InputForms
{
    public class GetInputFormQueryHandler : QueryHandler<GetInputFormCommand, InputFormDto>
    {
        private readonly IRemoteQuery<GetInputFormCommand, InputForm> _getInputFormQuery;

        private IMapper _mapper => AutoMapperFactory.CreateMapper<CommonMapperProfile<InputForm, InputFormDto>>();

        public GetInputFormQueryHandler(IRemoteQuery<GetInputFormCommand, InputForm> getInputFormQuery)
        {
            _getInputFormQuery = getInputFormQuery;
        }

        public override async Task<ActionResult<InputFormDto>> Handle(GetInputFormCommand command)
        {
            var inputFormQuery = await _getInputFormQuery.Query(command);
            if (inputFormQuery == null)
            {
                ActionResult<InputFormDto>.Error();
            }

            var inputFormDto = _mapper.Map<InputFormDto>(inputFormQuery);
            return ActionResult<InputFormDto>.Ok(inputFormDto);
        }
    }
}
