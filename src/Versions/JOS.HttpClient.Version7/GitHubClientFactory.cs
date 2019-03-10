using System;
using Microsoft.Extensions.DependencyInjection;

namespace JOSHttpClient.Version7
{
    public class GitHubClientFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public GitHubClientFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public GitHubClient Create()
        {
            return _serviceProvider.GetRequiredService<GitHubClient>();
        }
    }
}
