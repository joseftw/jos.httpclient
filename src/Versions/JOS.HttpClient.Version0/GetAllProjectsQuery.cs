using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using JOSHttpClient.Common.Domain;

namespace JOSHttpClient.Version0
{
    public class GetAllProjectsQuery
    {
        private readonly GitHubClient _gitHubClient;

        public GetAllProjectsQuery(GitHubClient gitHubClient)
        {
            _gitHubClient = gitHubClient ?? throw new ArgumentNullException(nameof(gitHubClient));
        }

        public IReadOnlyCollection<Project> Execute(CancellationToken cancellationToken)
        {
            var response = _gitHubClient.GetRepositories(cancellationToken);
            return response.Select(x => new Project(x.Name, x.Url, x.Stars)).ToArray();
        }
    }
}
