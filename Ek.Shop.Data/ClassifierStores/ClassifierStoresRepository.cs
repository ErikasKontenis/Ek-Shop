using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Domain.AngularComponents;
using Ek.Shop.Domain.Categories;
using Ek.Shop.Domain.ClassifierStores;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ek.Shop.Data.ClassifierStores
{
    /// <summary>
    /// Do not even think about implementing DbContext here. The whole classifierStoreRepository is supposed to take classifiers only from the RemoteQueries.
    /// </summary>
    public class ClassifierStoresRepository : IClassifierStoresRepository
    {
        private readonly IRemoteQuery<ListAngularComponentsCommand, List<AngularComponent>> _listAngularComponentsQuery;
        private readonly IRemoteQuery<ListCategoryTypesCommand, List<CategoryType>> _listCategoryTypesQuery;

        public ClassifierStoresRepository(IRemoteQuery<ListAngularComponentsCommand, List<AngularComponent>> listAngularComponentsQuery,
            IRemoteQuery<ListCategoryTypesCommand, List<CategoryType>> listCategoryTypesQuery)
        {
            _listAngularComponentsQuery = listAngularComponentsQuery;
            _listCategoryTypesQuery = listCategoryTypesQuery;
        }

        public async Task<ClassifierStore> Get()
        {
            var classifierStore = new ClassifierStore();
            classifierStore.AngularComponents = await _listAngularComponentsQuery.Query(new ListAngularComponentsCommand());
            classifierStore.CategoryTypes = await _listCategoryTypesQuery.Query(new ListCategoryTypesCommand());

            return classifierStore;
        }
    }
}
