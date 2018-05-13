using Ek.Shop.Base.Data.WorkContexts;

namespace Ek.Shop.Web.Infrastructure
{
    public class Bus : IBus
    {
        public IWorkContext WorkContext { get; }

        public IQueryProcessor QueryProcessor { get; }

        public Bus(IWorkContext workContext,
            IQueryProcessor queryProcessor)
        {
            WorkContext = workContext;
            QueryProcessor = queryProcessor;
        }
    }
}
