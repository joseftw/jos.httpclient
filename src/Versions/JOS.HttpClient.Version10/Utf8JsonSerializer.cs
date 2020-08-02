using System.IO;
using System.Threading.Tasks;
using Utf8Json;

namespace JOSHttpClient.Version10
{
    public class Utf8JsonSerializer
    {
        private readonly IJsonFormatterResolver _resolver;

        public Utf8JsonSerializer()
        {
            _resolver = JsonSerializer.DefaultResolver;
        }

        public void Serialize<T>(T response, Stream responseStream)
        {
            JsonSerializer.Serialize<T>(responseStream, response, _resolver);
        }

        public T Deserialize<T>(Stream requestStream)
        {
            return JsonSerializer.Deserialize<T>(requestStream, _resolver);
        }

        public Task SerializeAsync<T>(T response, Stream responseStream)
        {
            return JsonSerializer.SerializeAsync<T>(responseStream, response, _resolver);
        }

        public Task<T> DeserializeAsync<T>(Stream requestStream)
        {
            return JsonSerializer.DeserializeAsync<T>(requestStream, _resolver);
        }
    }
}
