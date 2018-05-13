using CacheManager.Core;
using Ek.Shop.Base.Data.Caches;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Contracts.Extensions;
using Ek.Shop.Core.Models;
using System.Threading.Tasks;

namespace Ek.Shop.Base.Data.Queries.RemoteQueries
{
    public class RemoteQueryCacheDecorator<TCommand, TResult> : IRemoteQuery<TCommand, TResult> where TResult : class where TCommand : ICommand
    {
        private readonly IRemoteQuery<TCommand, TResult> _decoratedRemoteQuery;
        private readonly ICache _cache;

        public RemoteQueryCacheDecorator(IRemoteQuery<TCommand, TResult> decoratedRemoteQuery,
            ICache cache)
        {
            _decoratedRemoteQuery = decoratedRemoteQuery;
            _cache = cache;
        }

        public CacheOptions CacheOptions => _decoratedRemoteQuery.CacheOptions;

        public string CacheRegion => _decoratedRemoteQuery.CacheRegion;

        public bool IsCacheRequired => _decoratedRemoteQuery.IsCacheRequired;

        public async Task<TResult> Query(TCommand command)
        {
            if (!IsCacheRequired)
            {
                return await _decoratedRemoteQuery.Query(command);
            }

            var commandCacheKey = typeof(TCommand).FullName + command.ToJson();
            var cachedItem = _cache.Get<TResult>(commandCacheKey, CacheRegion);
            if (cachedItem == null)
            {
                var item = await _decoratedRemoteQuery.Query(command);
                if (item == null)
                    return item;

                var cacheItem = new CacheItem<object>(commandCacheKey, CacheRegion, item, (ExpirationMode)CacheOptions.ExpirationMode, CacheOptions.Timeout);

                _cache.Add(cacheItem);

                return item;
            }

            return cachedItem;
        }
    }
}
