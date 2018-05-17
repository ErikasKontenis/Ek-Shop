using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Contracts.Commands;
using System.Threading.Tasks;

namespace Ek.Shop.Base.Data.Queries.RemoteQueries
{
    public abstract class RemoteQuery<TCommand, TResult> : IRemoteQuery<TCommand, TResult> where TResult : class where TCommand : ICommand
    {
        protected readonly EkShopContext DbContext;

        public RemoteQuery(EkShopContext dbContext)
        {
            DbContext = dbContext;
        }

        public abstract Task<TResult> Query(TCommand command);
    }
}
