using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using SimpleInjector;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Ek.Shop.Web.Infrastructure
{
    public sealed class QueryProcessor : IQueryProcessor
    {
        private readonly Container container;

        public QueryProcessor(Container container)
        {
            this.container = container;
        }

        [DebuggerStepThrough]
        public async Task<ActionResult<TResult>> GetQueryHandler<TCommand, TResult>(TCommand command) where TCommand : ICommand
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));
            dynamic handler = container.GetInstance(handlerType);

            return await handler.Handle((dynamic)command);
        }
    }
}
