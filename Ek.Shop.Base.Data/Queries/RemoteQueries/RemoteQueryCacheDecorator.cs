using CacheManager.Core;
using Ek.Shop.Base.Data.Caches;
using Ek.Shop.Contracts.Abstractions;
using Ek.Shop.Contracts.Extensions;
using System.Threading.Tasks;

namespace Ek.Shop.Base.Data.Queries.RemoteQueries
{
    public class RemoteQueryCacheDecorator<TCommand, TResult> : IRemoteQuery<TCommand, TResult> where TResult : class where TCommand : CachingCommand
    {
        private readonly IRemoteQuery<TCommand, TResult> _decoratedRemoteQuery;
        private readonly ICache _cache;

        public RemoteQueryCacheDecorator(IRemoteQuery<TCommand, TResult> decoratedRemoteQuery,
            ICache cache)
        {
            _decoratedRemoteQuery = decoratedRemoteQuery;
            _cache = cache;
        }

        public async Task<TResult> Query(TCommand command)
        {
            if (!command.IsFromCache)
            {
                return await _decoratedRemoteQuery.Query(command);
            }

            var commandCacheKey = typeof(TCommand).FullName + command.ToJson();
            var cachedItem = _cache.Get<TResult>(commandCacheKey, command.Region);
            if (cachedItem == null)
            {
                var item = await _decoratedRemoteQuery.Query(command);
                if (item == null)
                    return item;

                var cacheItem = new CacheItem<object>(commandCacheKey, command.Region, item, (ExpirationMode)command.ExpirationMode, command.Timeout);

                _cache.Add(cacheItem);

                return item;
            }

            return cachedItem;
        }
    }
}
