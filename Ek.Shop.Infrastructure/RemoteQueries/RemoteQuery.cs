using System;
using System.Threading.Tasks;

namespace Ek.Shop.Infrastructure.RemoteQueries
{
    public abstract class RemoteQuery<TParam, TResult> : IRemoteQuery<TParam, TResult>
    {
        protected readonly EkShopContext DbContext;
        private bool _disposed;

        public RemoteQuery(EkShopContext dbContext)
        {
            DbContext = dbContext;
        }

        private string _userEmail;

        public void Initialize(string userEmail)
        {
            _userEmail = userEmail;
        }

        public abstract Task<TResult> Query(TParam query);

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
