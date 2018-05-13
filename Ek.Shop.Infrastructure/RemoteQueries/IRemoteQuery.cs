using System.Threading.Tasks;

namespace Ek.Shop.Infrastructure.RemoteQueries
{
    public interface IRemoteQuery<TParam, TResult>
    {
        void Initialize(string userEmail);

        Task<TResult> Query(TParam query);
    }
}
