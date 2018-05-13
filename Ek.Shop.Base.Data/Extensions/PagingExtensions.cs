using Ek.Shop.Contracts.Abstractions;
using Ek.Shop.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Base.Data.Extensions
{
    public static class PagingExtensions
    {
        public static async Task<PagedList<TSource>> ToPagedListAsync<TSource>(this IQueryable<TSource> source)
        {
            var items = await source.ToListAsync();
            return new PagedList<TSource>(items, 1, 0, items.Count);
        }

        public static async Task<PagedList<TSource>> ToPagedListAsync<TSource, TCommand>(this IQueryable<TSource> source, TCommand command)
            where TCommand : PagingCommand
        {
            if (command.PageSize == 0)
                return new PagedList<TSource>(await source.ToListAsync());

            var totalItemsCount = await source.CountAsync();
            var sourceList = await source.Skip((command.PageIndex-1) * command.PageSize).Take(command.PageSize).ToListAsync();
            return new PagedList<TSource>(sourceList, command.PageIndex, command.PageSize, totalItemsCount);
        }

        public static PagedList<TSource> ToPagedList<TSource>(this IEnumerable<TSource> source)
        {
            return new PagedList<TSource>(source);
        }

        public static PagedList<TSource> ToPagedList<TSource, TCommand>(this IEnumerable<TSource> source, TCommand command)
            where TCommand : PagingCommand
        {
            if (command.PageSize == 0)
                return new PagedList<TSource>(source);

            var totalItemsCount = source.Count();
            var sourceList = source.Skip((command.PageIndex-1) * command.PageSize).Take(command.PageSize);
            return new PagedList<TSource>(sourceList, command.PageIndex, command.PageSize, totalItemsCount);
        }
    }
}
