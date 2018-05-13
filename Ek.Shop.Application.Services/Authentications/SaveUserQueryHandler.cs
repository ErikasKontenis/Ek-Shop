using AutoMapper;
using Ek.Shop.Application.ApplicationUser;
using Ek.Shop.Application.Classifiers;
using Ek.Shop.Application.Extensions;
using Ek.Shop.Application.Services.AutoMappers;
using Ek.Shop.Application.Services.AutoMappers.Profiles;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.WorkContexts;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Contracts.Extensions;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Users;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Authentications
{
    public class SaveUserQueryHandler : QueryHandler<SaveUserCommand, UserDto>
    {
        private readonly IQueryHandler<GetCategoryByUrlCommand, CategoryDto> _getCategoryByUrlQueryHandler;
        private readonly UserManager<User> _userManager;
        private readonly IWorkContext _workContext;

        private IMapper _mapper => AutoMapperFactory
            .CreateMapper<CommonMapperProfile<UserDto, User>>();

        public SaveUserQueryHandler(IQueryHandler<GetCategoryByUrlCommand, CategoryDto> getCategoryByUrlQueryHandler,
            UserManager<User> userManager,
            IWorkContext workContext)
        {
            _getCategoryByUrlQueryHandler = getCategoryByUrlQueryHandler;
            _userManager = userManager;
            _workContext = workContext;
        }

        public override async Task<ActionResult<UserDto>> Handle(SaveUserCommand command)
        {
            var categoryDtoResult = await _getCategoryByUrlQueryHandler.Handle(new GetCategoryByUrlCommand(command.RouteUrl, _workContext.WorkingLanguageId));
            if (categoryDtoResult.Failure)
            {
                return Error(categoryDtoResult.ErrorMessages);
            }

            var categoryDto = categoryDtoResult.Object;
            var detailErrors = categoryDto.Fieldsets.MapToFields(command.User).ValidateFieldsets();
            if (!detailErrors.IsNullOrEmpty())
            {
                return Error(detailErrors);
            }

            var workingUser = await _workContext.GetWorkingUser();
            if (workingUser == null)
            {
                return Error();
            }

            var user = _mapper.Map(command.User, workingUser);
            user.UserName = user.Email;

            var userUpdateResult = await _userManager.UpdateAsync(user);
            if (!userUpdateResult.Succeeded)
            {
                return Error(userUpdateResult.Errors.Select(o => o.Description).ToHeaderErrors());
            }

            return Ok(new UserDto());
        }
    }
}
