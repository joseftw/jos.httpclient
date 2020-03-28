using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JOSHttpClient.Common
{
    public interface IGitHubClient
    {
        Task<IReadOnlyCollection<GitHubRepositoryDto>> GetRepositories(CancellationToken cancellationToken);
    }
}
