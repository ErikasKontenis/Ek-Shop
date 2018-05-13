using Ek.Shop.Base.Data.Queries.RemoteQuery;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Domain.Categories;

namespace Ek.Shop.Data.Categories
{
    public interface IGetCategoryQuery : IRemoteQuery<GetCategoryCommand, Category>
    { }
}
