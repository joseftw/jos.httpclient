using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using JOSHttpClient.Common;
using Newtonsoft.Json;

namespace JOSHttpClient.Version2
{
    public class GitHubClient : IGitHubClient
    {
        private readonly HttpClient _httpClient;

        public GitHubClient()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(GitHubConstants.ApiBaseUrl) };
        }

        public async Task<IReadOnlyCollection<GitHubRepositoryDto>> GetRepositories()
        {
            var result = await _httpClient.GetStringAsync(GitHubConstants.RepositoriesPath).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<GitHubRepositoryDto>>(result);
        }
    }
}
