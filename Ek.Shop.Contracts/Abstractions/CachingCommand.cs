using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Enums;
using System;

namespace Ek.Shop.Contracts.Abstractions
{
    public abstract class CachingCommand : ICommand
    {
        public CachingCommand()
        { }

        public abstract string Region { get; }

        public virtual int ExpirationMode { get { return CacheExpirationModes.Absolute; } }

        public bool IsFromCache { get; set; } = true;

        public TimeSpan Timeout { get; set; } = TimeSpan.FromMinutes(15);
    }
}
