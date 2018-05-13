using Ek.Shop.Application.ApplicationUser;
using Ek.Shop.Application.Classifiers;
using Ek.Shop.Application.Extensions;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.WorkContexts;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Contracts.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Users;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Authentications
{
    public class LoginUserQueryHandler : QueryHandler<LoginUserCommand, UserDto>
    {
        private readonly IQueryHandler<GetCategoryByUrlCommand, CategoryDto> _getCategoryByUrlQueryHandler;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IWorkContext _workContext;

        public LoginUserQueryHandler(IQueryHandler<GetCategoryByUrlCommand, CategoryDto> getCategoryByUrlQueryHandler,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IWorkContext workContext)
        {
            _getCategoryByUrlQueryHandler = getCategoryByUrlQueryHandler;
            _userManager = userManager;
            _signInManager = signInManager;
            _workContext = workContext;
        }

        public override async Task<ActionResult<UserDto>> Handle(LoginUserCommand command)
        {
            var loginCategoryDtoResult = await _getCategoryByUrlQueryHandler.Handle(new GetCategoryByUrlCommand(command.LoginData.RouteUrl, _workContext.WorkingLanguageId));
            if (loginCategoryDtoResult.Failure)
            {
                return Error(loginCategoryDtoResult.ErrorMessages);
            }

            var loginCategoryDto = loginCategoryDtoResult.Object;
            var detailErrors = loginCategoryDto.Fieldsets.MapToFields(command.LoginData).ValidateFieldsets();
            if (!detailErrors.IsNullOrEmpty())
            {
                return Error(detailErrors);
            }

            var userSignInResult = await _signInManager.PasswordSignInAsync(command.LoginData.Email, command.LoginData.Password, command.LoginData.IsRemember, lockoutOnFailure: false);
            if (!userSignInResult.Succeeded)
            {
                return Error(new Dictionary<string, DetailError>() { { "", new DetailError(DetailErrorTypes.HeaderErrors, "Neteisingi prisijungimo duomenys.") } });
            }

            return Ok(new UserDto());
        }
    }
}
