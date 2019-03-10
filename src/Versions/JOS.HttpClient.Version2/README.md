### GitHubClient

```csharp
public class GitHubClient : IGitHubClient
{
    private readonly HttpClient _httpClient;

    public GitHubClient()
    {
        _httpClient = new HttpClient { BaseAddress = new Uri(GitHubConstants.ApiBaseUrl) };
    }

    public async Task<IReadOnlyCollection<GitHubRepositoryDto>> GetRepositories()
    {
        var result = await _httpClient.GetStringAsync("/api/github/repositories").ConfigureAwait(false);
        return JsonConvert.DeserializeObject<List<GitHubRepositoryDto>>(result);
    }
}
```

Here we are creating a new HttpClient when constructing the class and then reuse it.
This is better than before, but still not good.
TODO Explain about DNS issues and stuff
