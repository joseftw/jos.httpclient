### GitHubClient

```csharp
public class GitHubClient : IGitHubClient
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializer _jsonSerializer;

    public GitHubClient(HttpClient httpClient, JsonSerializer jsonSerializer)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _jsonSerializer = jsonSerializer ?? throw new ArgumentNullException(nameof(jsonSerializer));
    }

    public async Task<IReadOnlyCollection<GitHubRepositoryDto>> GetRepositories()
    {
        var request = CreateRequest();
        using (var result = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false))
        {
            using (var responseStream = await result.Content.ReadAsStreamAsync())
            {
                using (var streamReader = new StreamReader(responseStream))
                using (var jsonTextReader = new JsonTextReader(streamReader))
                {
                    return _jsonSerializer.Deserialize<List<GitHubRepositoryDto>>(jsonTextReader);
                }
            }
        }
    }

    private static HttpRequestMessage CreateRequest()
    {
        return new HttpRequestMessage(HttpMethod.Get, "/api/github/repositories");
    }
}
```
