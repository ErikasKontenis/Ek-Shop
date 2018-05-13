using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using System.Threading.Tasks;

namespace Ek.Shop.Base.Data.Queries.RemoteQueries
{
    public interface IRemoteQuery<TCommand, TResult> where TResult : class where TCommand : ICommand
    {
        CacheOptions CacheOptions { get; }

        string CacheRegion { get; }

        bool IsCacheRequired { get; }

        Task<TResult> Query(TCommand command);
    }
}
