using Ek.Shop.Application.ApplicationUser;
using Ek.Shop.Application.Authentication;
using Ek.Shop.Application.Profiles;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ek.Shop.Web.ControllersApi.Common
{
    [ResponseCache(CacheProfileName = "ResponseCachingNever")]
    [Route("api/[controller]")]
    public class AuthenticationController : ApiControllerAsync
    {
        public AuthenticationController(IBus bus)
            : base(bus)
        { }

        [HttpGet("[action]")]
        public async Task<IActionResult> Authenticate()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return BadRequest();
            }

            var userDtoResult = await QueryProcessor.GetQueryHandler<AuthenticateUserCommand, UserDto>(new AuthenticateUserCommand());
            if (userDtoResult.Failure)
            {
                return BadRequest(userDtoResult.ErrorMessages);
            }

            var userDto = userDtoResult.Object;
            return Ok(userDto);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProfile()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return BadRequest();
            }

            var profileDtoResult = await QueryProcessor.GetQueryHandler<GetProfileCommand, ProfileDto>(new GetProfileCommand());
            if (profileDtoResult.Failure)
            {
                return BadRequest(profileDtoResult.ErrorMessages);
            }

            var profileDto = profileDtoResult.Object;
            return Ok(profileDto);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody]LoginDataDto loginData)
        {
            var userDtoResult = await QueryProcessor.GetQueryHandler<LoginUserCommand, UserDto>(new LoginUserCommand(loginData));
            if (userDtoResult.Failure)
            {
                return BadRequest(userDtoResult.ErrorMessages);
            }

            return Ok(true);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Logout()
        {
            var userDtoResult = await QueryProcessor.GetQueryHandler<LogoutUserCommand, UserDto>(new LogoutUserCommand());
            if (userDtoResult.Failure)
            {
                return BadRequest(userDtoResult.ErrorMessages);
            }

            return Ok(true);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody]RegistrationDataDto registrationData)
        {
            var userDtoResult = await QueryProcessor.GetQueryHandler<CreateUserCommand, UserDto>(new CreateUserCommand(registrationData));
            if (userDtoResult.Failure)
            {
                return BadRequest(userDtoResult.ErrorMessages);
            }

            return Ok(true);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SaveUser([FromBody]SaveUserCommand command)
        {
            var userDtoResult = await QueryProcessor.GetQueryHandler<SaveUserCommand, UserDto>(command);
            if (userDtoResult.Failure)
            {
                return BadRequest(userDtoResult.ErrorMessages);
            }

            return Ok(true);
        }
    }
}
