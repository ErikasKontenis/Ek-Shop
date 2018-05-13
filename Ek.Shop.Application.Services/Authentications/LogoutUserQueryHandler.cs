using Ek.Shop.Application.ApplicationUser;
using Ek.Shop.Application.Classifiers;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Users;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Authentications
{
    public class LogoutUserQueryHandler : QueryHandler<LogoutUserCommand, UserDto>
    {
        private readonly IQueryHandler<GetCategoryByUrlCommand, CategoryDto> _getCategoryByUrlQueryHandler;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public LogoutUserQueryHandler(IQueryHandler<GetCategoryByUrlCommand, CategoryDto> getCategoryByUrlQueryHandler,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _getCategoryByUrlQueryHandler = getCategoryByUrlQueryHandler;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public override async Task<ActionResult<UserDto>> Handle(LogoutUserCommand command)
        {
            await _signInManager.SignOutAsync();

            return Ok(new UserDto());
        }
    }
}
