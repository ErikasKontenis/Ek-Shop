using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Contracts.Commands;
using System;
using System.Linq;

namespace Ek.Shop.Base.Data.Queries.Queries
{
    public abstract class Query<TCommand, TResult> : IQuery<TCommand, TResult> where TResult : class where TCommand : ICommand
    {
        protected readonly EkShopContext DbContext;
        private bool _disposed;

        public Query(EkShopContext dbContext)
        {
            DbContext = dbContext;
        }

        public abstract IQueryable<TResult> Execute(TCommand command);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
