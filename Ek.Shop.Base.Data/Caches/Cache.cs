using CacheManager.Core;
using Ek.Shop.Core.Models;
using System;

namespace Ek.Shop.Base.Data.Caches
{
    public class Cache : ICache
    {
        private readonly int _cacheTimeout = 15;
        private readonly ICacheManager<object> _cacheManager;

        public Cache(ICacheManager<object> cacheManager)
        {
            _cacheManager = cacheManager;
        }

        public bool Add(CacheItem<object> item)
        {
            return _cacheManager.Add(item);
        }

        public void Clear()
        {
            _cacheManager.Clear();
        }

        public void ClearRegion(string region)
        {
            _cacheManager.ClearRegion(region);
        }

        public TCacheValue Get<TCacheValue>(string key)
        {
            return (TCacheValue)_cacheManager.Get(key);
        }

        public TCacheValue Get<TCacheValue>(string key, string region)
        {
            return (TCacheValue)_cacheManager.Get(key, region);
        }

        public TCacheValue GetOrAdd<TCacheValue>(string key, string region, Func<TCacheValue> valueFactory, CacheOptions cacheOptions = null)
        {
            var cachedItem = Get<TCacheValue>(key, region);
            if (cachedItem == null)
            {
                var item = valueFactory.Invoke();
                if (item == null)
                    return item;

                if (cacheOptions == null || cacheOptions.ExpirationMode == 0)
                    cacheOptions.ExpirationMode = (int)ExpirationMode.Absolute;

                var cacheItem = new CacheItem<object>(key, region, item, (ExpirationMode)cacheOptions.ExpirationMode, cacheOptions?.Timeout ?? TimeSpan.FromMinutes(_cacheTimeout));

                Add(cacheItem);

                return item;
            }

            return cachedItem;
        }
    }
}
