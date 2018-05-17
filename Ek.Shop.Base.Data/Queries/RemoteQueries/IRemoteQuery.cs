using Ek.Shop.Contracts.Commands;
using System.Threading.Tasks;

namespace Ek.Shop.Base.Data.Queries.RemoteQueries
{
    public interface IRemoteQuery<TCommand, TResult> where TResult : class where TCommand : ICommand
    {
        Task<TResult> Query(TCommand command);
    }
}
