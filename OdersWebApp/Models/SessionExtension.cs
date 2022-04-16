using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace OdersWebApp.Models
{
    public static class SessionExtension
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetObject<T>(this ISession session, string key)
        {
            var val = session.GetString(key);
            return (string.IsNullOrEmpty(val)) ? default(T) :
                JsonConvert.DeserializeObject<T>(val);
        }
    }
}
