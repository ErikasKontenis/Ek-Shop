using Ek.Shop.Domain.Users;
using System.Threading.Tasks;

namespace Ek.Shop.Base.Data.WorkContexts
{
    public interface IWorkContext
    {
        int WorkingInputFormId { get; set; }

        string WorkingInputFormName { get; set; }

        int WorkingLanguageId { get; set; }

        string WorkingLanguageName { get; set; }

        Task<User> GetWorkingUser();
    }
}
