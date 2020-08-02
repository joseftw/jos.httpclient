### GitHubClient

```csharp
public class GitHubClient : IGitHubClient
{
    private readonly HttpClient _httpClient;
    private readonly Utf8JsonSerializer _jsonSerializer;

    public GitHubClient(HttpClient httpClient, Utf8JsonSerializer jsonSerializer)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _jsonSerializer = jsonSerializer ?? throw new ArgumentNullException(nameof(jsonSerializer));
    }

    public async Task<IReadOnlyCollection<GitHubRepositoryDto>> GetRepositories(CancellationToken cancellationToken)
    {
        var request = CreateRequest();
        var result = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
        using (var responseStream = await result.Content.ReadAsStreamAsync())
        {
            return await _jsonSerializer.DeserializeAsync<List<GitHubRepositoryDto>>(responseStream);
        }
    }

    private static HttpRequestMessage CreateRequest()
    {
        return new HttpRequestMessage(HttpMethod.Get, GitHubConstants.RepositoriesPath);
    }
}

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
```

TODO talk about ResponseHeadersRead and stuff.