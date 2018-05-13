using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using System.Threading.Tasks;

namespace Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler
{
    public interface IQueryHandler<TCommand, TResult> where TCommand : ICommand
    {
        Task<ActionResult<TResult>> Handle(TCommand command);
    }
}
