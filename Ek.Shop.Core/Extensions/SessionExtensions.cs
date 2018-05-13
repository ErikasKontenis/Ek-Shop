using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Ek.Shop.Core.Extensions
{
    public static class SessionExtensions
    {
        public static void SetObject<T>(this ISession session, T value)
            where T : class
        {
            session.SetString(typeof(T).FullName, JsonConvert.SerializeObject(value));
        }

        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session)
            where T : class
        {
            var value = session.GetString(typeof(T).FullName);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            if (string.IsNullOrEmpty(value))
            {
                return default(T);
            }

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
