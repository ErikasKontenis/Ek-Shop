using CacheManager.Core;
using Ek.Shop.Base.Data.Caches;
using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.WorkContexts;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace Ek.Shop.Tests
{
    public class TestUtil
    {
        public static ICache Cache => new Cache(CacheFactory.Build<object>("EkShopTests", settings =>
            {
            settings.WithDictionaryHandle();
        }));

        public static EkShopContext DbContext => new EkShopContext();

        public static IWorkContext WorkContext => new WorkContext(new HttpContextAccessor() { HttpContext = new DefaultHttpContext() { Session = new TestSession() } }, new UserManager<User>(new Mock<IUserStore<User>>().Object, null, null, null, null, null, null, null, null)) { WorkingInputFormId = 1, WorkingInputFormName = InputFormCodes.Admin, WorkingLanguageId = 2 };
    }
}
