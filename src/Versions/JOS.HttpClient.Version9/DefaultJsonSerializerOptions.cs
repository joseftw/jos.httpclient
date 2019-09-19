using System.Text.Json;
using System.Text.Json.Serialization;

namespace JOSHttpClient.Version9
{
    public static class DefaultJsonSerializerOptions
    {
        public static JsonSerializerOptions Options => new JsonSerializerOptions {PropertyNameCaseInsensitive = true};
    }
}
