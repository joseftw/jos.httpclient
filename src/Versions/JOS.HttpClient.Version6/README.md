### GitHubClient

```csharp
public class GitHubClient : IGitHubClient
{
    private readonly HttpClient _httpClient;

    public GitHubClient(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<IReadOnlyCollection<GitHubRepositoryDto>> GetRepositories()
    {
        var request = CreateRequest();
        var result = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

        using (var streamReader = new StreamReader(await result.Content.ReadAsStreamAsync()))
        using (var jsonTextReader = new JsonTextReader(streamReader))
        {
            var serializer = new JsonSerializer();
            return serializer.Deserialize<List<GitHubRepositoryDto>>(jsonTextReader);
        }
    }

    private static HttpRequestMessage CreateRequest()
    {
        return new HttpRequestMessage(HttpMethod.Get, "/api/github/repositories");
    }
}
```

Here we are injecting a new HttpClient for each call to the method, but we have registered ```GetAllProjectsQuery``` as a singleton instead of transient.
TODO talk about json deserialization and streams etc.