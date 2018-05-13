using CacheManager.Core;
using Ek.Shop.Core.Models;
using System;

namespace Ek.Shop.Base.Data.Caches
{
    public interface ICache
    {
        //
        // Summary:
        //     Adds the specified CacheItem to the cache.
        //     Use this overload to overrule the configured expiration settings of the cache
        //     and to define a custom expiration for this item only.
        //     The Add method will not be successful if the specified item already exists within
        //     the cache!
        //
        // Parameters:
        //   item:
        //     The CacheItem to be added to the cache.
        //
        // Returns:
        //     true if the key was not already added to the cache, false otherwise.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     If the item or the item's key or value is null.
        bool Add(CacheItem<object> item);

        //
        // Summary:
        //     Clears this cache, removing all items in the base cache and all regions.
        void Clear();

        //
        // Summary:
        //     Clears the cache region, removing all items from the specified region only.
        //
        // Parameters:
        //   region:
        //     The cache region.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     If the region is null.
        void ClearRegion(string region);

        //
        // Summary:
        //     Gets a value for the specified key.
        //
        // Parameters:
        //   key:
        //     The key being used to identify the item within the cache.
        //
        // Returns:
        //     The value being stored in the cache for the given key.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     If the key is null.
        TCacheValue Get<TCacheValue>(string key);

        //
        // Summary:
        //     Gets a value for the specified key and region.
        //
        // Parameters:
        //   key:
        //     The key being used to identify the item within the cache.
        //
        //   region:
        //     The cache region.
        //
        // Returns:
        //     The value being stored in the cache for the given key and region.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     If the key or region is null.
        TCacheValue Get<TCacheValue>(string key, string region);

        TCacheValue GetOrAdd<TCacheValue>(string key, string region, Func<TCacheValue> valueFactory, CacheOptions cacheOptions = null);
    }
}
