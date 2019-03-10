### GitHubClient

```csharp
public IReadOnlyCollection<GitHubRepositoryDto> GetRepositories()
{
    using (var httpClient = new HttpClient{BaseAddress = new Uri(GitHubConstants.ApiBaseUrl)})
    {
        var result = httpClient.GetStringAsync("/api/github/repositories").Result;
        return JsonConvert.DeserializeObject<List<GitHubRepositoryDto>>(result);
    }
}
```

This is horrible, using .Result on GetStringAsync. Don't do this, ever.
Unfortunately this is rather common, people who are not used to async or just wants to make quickfixes usually just adds a .Result and doesn't think twice about it. Don't be that person.
