using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler
{
    public abstract class QueryHandler<TCommand, TResult> : IQueryHandler<TCommand, TResult> where TCommand : ICommand
    {
        public abstract Task<ActionResult<TResult>> Handle(TCommand command);

        public virtual ActionResult<TResult> Error()
        {
            return ActionResult<TResult>.Error();
        }

        public virtual ActionResult<TResult> Error(Dictionary<string, DetailError> errorMessages)
        {
            return ActionResult<TResult>.Error(errorMessages);
        }

        public virtual ActionResult<TResult> Ok(TResult result)
        {
            return ActionResult<TResult>.Ok(result);
        }
    }
}
