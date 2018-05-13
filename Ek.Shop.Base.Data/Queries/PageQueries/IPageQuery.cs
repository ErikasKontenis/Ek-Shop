using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;

namespace Ek.Shop.Base.Data.Queries.PageQueries
{
    public interface IPageQuery<TCommand, TResult> where TResult : class where TCommand : ICommand
    {
        MemoryCacheEntryOptions CacheOptions { get; }

        bool IsCacheRequired { get; }

        Task<PagedList<TResult>> Query(TCommand command);
    }
}
