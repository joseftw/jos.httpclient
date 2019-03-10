### GitHubClient

```csharp
public class GitHubClient : IGitHubClient
{
    private readonly IHttpClientFactory _httpClientFactory;

    public GitHubClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
    }

    public async Task<IReadOnlyCollection<GitHubRepositoryDto>> GetRepositories()
    {
        var httpClient = _httpClientFactory.CreateClient("GitHub");

        var result = await httpClient.GetStringAsync("/api/github/repositories").ConfigureAwait(false);
        return JsonConvert.DeserializeObject<List<GitHubRepositoryDto>>(result);
    }
}
```

Here we are using the ```IHttpClientFactory``` and create a new HttpClient for each call to the method.
This is better than before, but still not good.
TODO: talk about Typed HttpClients and stuff
