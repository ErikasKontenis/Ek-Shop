using AutoMapper;
using Ek.Shop.Application.ApplicationUser;
using Ek.Shop.Application.Services.AutoMappers;
using Ek.Shop.Application.Services.AutoMappers.Profiles;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.WorkContexts;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Users;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Authentications
{
    public class AuthenticateUserQueryHandler : QueryHandler<AuthenticateUserCommand, UserDto>
    {
        private readonly IWorkContext _workContext;

        private IMapper _mapper => AutoMapperFactory
            .CreateMapper<CommonMapperProfile<User, UserDto>>();

        public AuthenticateUserQueryHandler(IWorkContext workContext)
        {
            _workContext = workContext;
        }

        public override async Task<ActionResult<UserDto>> Handle(AuthenticateUserCommand command)
        {
            var user = await _workContext.GetWorkingUser();
            if (user == null)
            {
                return Error();
            }

            var userDto = new UserDto();
            _mapper.Map(user, userDto);

            return Ok(userDto);
        }
    }
}
