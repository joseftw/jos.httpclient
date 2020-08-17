using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using JOSHttpClient.Common;
using Utf8Json;

namespace JOSHttpClient.Version10
{
    public class GitHubClient : IGitHubClient
    {
        private readonly HttpClient _httpClient;
        private readonly Utf8JsonSerializer _jsonSerializer;

        public GitHubClient(HttpClient httpClient, Utf8JsonSerializer jsonSerializer)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _jsonSerializer = jsonSerializer ?? throw new ArgumentNullException(nameof(jsonSerializer));
        }

        public async Task<IReadOnlyCollection<GitHubRepositoryDto>> GetRepositories(CancellationToken cancellationToken)
        {
            var request = CreateRequest();
            using (var result = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false))
            {
                using (var responseStream = await result.Content.ReadAsStreamAsync())
                {
                    return await _jsonSerializer.DeserializeAsync<List<GitHubRepositoryDto>>(responseStream);
                }
            }
        }

        private static HttpRequestMessage CreateRequest()
        {
            return new HttpRequestMessage(HttpMethod.Get, GitHubConstants.RepositoriesPath);
        }
    }
}
