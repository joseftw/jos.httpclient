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

Here we are injecting a new HttpClient for each call to the method, but we have registered ```GetAllProjectsQuery``` as a singleton instead of transient.
TODO Link to Steves blog post and talk about GitHubClientFactory