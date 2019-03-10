### GitHubClient

```csharp
public class GitHubClient : IGitHubClient
{
    public async Task<IReadOnlyCollection<GitHubRepositoryDto>> GetRepositories()
    {
        using (var httpClient = new HttpClient { BaseAddress = new Uri(GitHubConstants.ApiBaseUrl) })
        {
            var result = await httpClient.GetStringAsync("/api/github/repositories").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<GitHubRepositoryDto>>(result);
        }
    }
}
```

Here we are creating a new HttpClient for each call to the method and then dispose it when we are done (using).
**This is bad, don't do it.**
TODO förklara varför och länka till ASP.Net Monsters
