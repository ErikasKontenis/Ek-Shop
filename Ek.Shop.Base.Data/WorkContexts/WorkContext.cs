using Ek.Shop.Core.Extensions;
using Ek.Shop.Domain.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Ek.Shop.Base.Data.WorkContexts
{
    public class WorkContext : IWorkContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public WorkContext(IHttpContextAccessor httpContextAccessor,
            UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public int WorkingInputFormId
        {
            get
            {
                {
                    var value = _httpContextAccessor.HttpContext.Session.GetObject<int>(nameof(WorkingInputFormId));
                    return value;
                }
            }

            set { _httpContextAccessor.HttpContext.Session.SetObject(nameof(WorkingInputFormId), value); }
        }

        public string WorkingInputFormName
        {
            get
            {
                {
                    var value = _httpContextAccessor.HttpContext.Session.GetObject<string>(nameof(WorkingInputFormName));
                    return value;
                }
            }

            set { _httpContextAccessor.HttpContext.Session.SetObject(nameof(WorkingInputFormName), value); }
        }

        public int WorkingLanguageId
        {
            get
            {
                {
                    var value = _httpContextAccessor.HttpContext.Session.GetObject<int>(nameof(WorkingLanguageId));
                    return value;
                }
            }

            set { _httpContextAccessor.HttpContext.Session.SetObject(nameof(WorkingLanguageId), value); }
        }

        public string WorkingLanguageName
        {
            get
            {
                {
                    var value = _httpContextAccessor.HttpContext.Session.GetObject<string>(nameof(WorkingLanguageName));
                    return value;
                }
            }

            set { _httpContextAccessor.HttpContext.Session.SetObject(nameof(WorkingLanguageName), value); }
        }

        public async Task<User> GetWorkingUser()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            if (user == null)
            {
                return null;
            }

            var roles = await _userManager.GetRolesAsync(user);
            user.Roles = roles;

            return user;
        }
    }
}
