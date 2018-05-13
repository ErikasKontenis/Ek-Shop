using System;

namespace Ek.Shop.Core.Models
{
    public class CacheOptions
    {
        public int ExpirationMode { get; set; }

        public TimeSpan Timeout { get; set; }
    }
}
