using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JOSHttpClient.Common;
using JOSHttpClient.Common.Domain;

namespace JOSHttpClient.Version1
{
    public class GetAllProjectsQuery : IGetAllProjectsQuery
    {
        private readonly GitHubClient _gitHubClient;

        public GetAllProjectsQuery(GitHubClient gitHubClient)
        {
            _gitHubClient = gitHubClient ?? throw new ArgumentNullException(nameof(gitHubClient));
        }

        public async Task<IReadOnlyCollection<Project>> Execute(CancellationToken cancellationToken)
        {
            var response = await _gitHubClient.GetRepositories(cancellationToken).ConfigureAwait(false);
            return response.Select(x => new Project(x.Name, x.Url, x.Stars)).ToArray();
        }
    }
}
