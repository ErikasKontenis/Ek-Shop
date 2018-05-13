using Ek.Shop.Base.Data.WorkContexts;

namespace Ek.Shop.Web.Infrastructure
{
    public interface IBus
    {
        IWorkContext WorkContext { get; }

        IQueryProcessor QueryProcessor { get; }
    }
}
