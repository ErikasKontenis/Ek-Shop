using Ek.Shop.Application.Categories;

namespace Ek.Shop.Application.Interfaces.Categories
{
    public interface ICategory
    {
        CategoryDto GetCategoryByRoute(int routeId);
    }
}
