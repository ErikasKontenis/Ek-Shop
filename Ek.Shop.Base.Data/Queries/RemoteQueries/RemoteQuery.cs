using CacheManager.Core;
using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Enums;
using Ek.Shop.Core.Models;
using System;
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

        public virtual CacheOptions CacheOptions => new CacheOptions()
        {
            ExpirationMode = (int)ExpirationMode.Absolute,
            Timeout = TimeSpan.FromMinutes(15)

        };

        public virtual string CacheRegion => CacheRegions.Default;

        public virtual bool IsCacheRequired => true;

        public abstract Task<TResult> Query(TCommand command);
    }
}
