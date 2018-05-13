using Ek.Shop.Contracts.Commands;
using System.Linq;

namespace Ek.Shop.Base.Data.Queries.Queries
{
    public interface IQuery<TCommand, TResult> where TResult : class where TCommand : ICommand
    {
        IQueryable<TResult> Execute(TCommand query);
    }
}
