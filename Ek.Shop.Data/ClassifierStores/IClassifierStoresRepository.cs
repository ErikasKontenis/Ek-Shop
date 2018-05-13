using Ek.Shop.Domain.ClassifierStores;
using System.Threading.Tasks;

namespace Ek.Shop.Data.ClassifierStores
{
    public interface IClassifierStoresRepository
    {
        Task<ClassifierStore> Get();
    }
}
