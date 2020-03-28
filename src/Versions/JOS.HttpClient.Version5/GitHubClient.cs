using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using JOSHttpClient.Common;
using Newtonsoft.Json;

namespace JOSHttpClient.Version5
{
    public class GitHubClient : IGitHubClient
    {
        private readonly HttpClient _httpClient;

        public GitHubClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IReadOnlyCollection<GitHubRepositoryDto>> GetRepositories(CancellationToken cancellationToken)
        {
            var result = await _httpClient.GetStringAsync(GitHubConstants.RepositoriesPath).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<GitHubRepositoryDto>>(result);
        }
    }
}
