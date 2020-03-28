using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using JOSHttpClient.Common;
using Newtonsoft.Json;

namespace JOSHttpClient.Version3
{
    public class GitHubClient : IGitHubClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GitHubClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<IReadOnlyCollection<GitHubRepositoryDto>> GetRepositories(CancellationToken cancellationToken)
        {
            var httpClient = _httpClientFactory.CreateClient("GitHub");
            var result = await httpClient.GetStringAsync(GitHubConstants.RepositoriesPath).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<GitHubRepositoryDto>>(result);
        }
    }
}
