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
        var result = await _httpClient.GetStringAsync("/api/github/repositories").ConfigureAwait(false);
        return JsonConvert.DeserializeObject<List<GitHubRepositoryDto>>(result);
    }
}
```

Here we are injecting a new ```HttpClient``` for each call to the method with the help of ```IHttpClientFactory```.
TODO Talk about Transient/Singleton