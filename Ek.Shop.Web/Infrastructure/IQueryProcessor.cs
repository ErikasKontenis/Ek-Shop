using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using System.Threading.Tasks;

namespace Ek.Shop.Web.Infrastructure
{
    public interface IQueryProcessor
    {
        Task<ActionResult<TResult>> GetQueryHandler<TCommand, TResult>(TCommand command) where TCommand : ICommand;
    }
}
