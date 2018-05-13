using System.Linq;

namespace Ek.Shop.Contracts.Extensions
{
    public static class ReflectionExtensions
    {
        public static object GetPropertyValue(this object source, string propertyName)
        {
            return source.GetType().GetProperties()
               .FirstOrDefault(pi => pi.Name == propertyName)
               ?.GetValue(source, null);
        }
    }
}
