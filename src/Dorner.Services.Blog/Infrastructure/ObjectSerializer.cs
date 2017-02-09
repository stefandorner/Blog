using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Dorner.BlogEngineCore.Infrastructure
{
    internal static class ObjectSerializer
    {
        private readonly static JsonSerializerSettings settings = new JsonSerializerSettings
        {
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore
        };

        private readonly static JsonSerializer serializer = new JsonSerializer
        {
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore
        };

        public static string ToString(object o)
        {
            return JsonConvert.SerializeObject(o, settings);
        }

        public static JObject ToJObject(object o)
        {
            return JObject.FromObject(o, serializer);
        }
    }
}
