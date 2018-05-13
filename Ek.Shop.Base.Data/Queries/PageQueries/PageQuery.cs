using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace Ek.Shop.Base.Data.Queries.PageQueries
{
    public abstract class PageQuery<TCommand, TResult> : IPageQuery<TCommand, TResult> where TResult : class where TCommand : ICommand
    {
        protected readonly EkShopContext DbContext;

        public PageQuery(EkShopContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual MemoryCacheEntryOptions CacheOptions => new MemoryCacheEntryOptions()
        {
            // Commented for a while because no cache need anywhere
            //AbsoluteExpiration = Debugger.IsAttached ? DateTime.Now : DateTime.Now.AddMinutes(60),
            //SlidingExpiration = Debugger.IsAttached ? TimeSpan.FromMilliseconds(1) : TimeSpan.FromMinutes(30)
            AbsoluteExpiration = DateTime.Now,
            SlidingExpiration = TimeSpan.FromMilliseconds(1)

        };

        public virtual bool IsCacheRequired => true;

        public abstract Task<PagedList<TResult>> Query(TCommand command);
    }
}
