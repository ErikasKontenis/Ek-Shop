using AutoMapper;
using Ek.Shop.Application.ApplicationUser;
using Ek.Shop.Application.Authentication;
using Ek.Shop.Application.Classifiers;
using Ek.Shop.Application.Extensions;
using Ek.Shop.Application.Services.AutoMappers;
using Ek.Shop.Application.Services.AutoMappers.Profiles;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.WorkContexts;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Contracts.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Users;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Authentications
{
    public class CreateUserQueryHandler : QueryHandler<CreateUserCommand, UserDto>
    {
        private readonly IQueryHandler<GetCategoryByUrlCommand, CategoryDto> _getCategoryByUrlQueryHandler;
        private readonly UserManager<User> _userManager;
        private readonly IWorkContext _workContext;

        private IMapper _mapper => AutoMapperFactory
            .CreateMapper<CommonMapperProfile<RegistrationDataDto, User>>();

        public CreateUserQueryHandler(IQueryHandler<GetCategoryByUrlCommand, CategoryDto> getCategoryByUrlQueryHandler,
            UserManager<User> userManager,
            IWorkContext workContext)
        {
            _getCategoryByUrlQueryHandler = getCategoryByUrlQueryHandler;
            _userManager = userManager;
            _workContext = workContext;
        }

        public override async Task<ActionResult<UserDto>> Handle(CreateUserCommand command)
        {
            var categoryDtoResult = await _getCategoryByUrlQueryHandler.Handle(new GetCategoryByUrlCommand(command.RegistrationData.RouteUrl, _workContext.WorkingLanguageId));
            if (categoryDtoResult.Failure)
            {
                return Error(categoryDtoResult.ErrorMessages);
            }

            var categoryDto = categoryDtoResult.Object;
            var detailErrors = categoryDto.Fieldsets.MapToFields(command.RegistrationData).ValidateFieldsets();
            if (!detailErrors.IsNullOrEmpty())
            {
                return Error(detailErrors);
            }

            if (command.RegistrationData.Password != command.RegistrationData.PasswordConfirmation)
            {
                // TODO: take this error message from phrases
                return Error(new Dictionary<string, DetailError>()
                {
                    { "headerErrors", new DetailError(DetailErrorTypes.HeaderErrors, "Nesutampa slaptažodis su patvirtinamuoju slaptažodžiu") }
                });
            }

            var user = _mapper.Map<User>(command.RegistrationData);
            user.UserName = user.Email;
            var userAddResult = await _userManager.CreateAsync(user, command.RegistrationData.Password);
            if (!userAddResult.Succeeded)
            {
                return Error(userAddResult.Errors.Select(o => o.Description).ToHeaderErrors());
            }

            // Add to roles
            var roleAddResult = await _userManager.AddToRoleAsync(user, "User");
            if (!roleAddResult.Succeeded)
            {
                return Error(userAddResult.Errors.Select(o => o.Description).ToHeaderErrors());
            }

            return Ok(new UserDto());
        }
    }
}
