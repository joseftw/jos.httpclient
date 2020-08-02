using System;
using JOSHttpClient.Common;
using Microsoft.Extensions.DependencyInjection;

namespace JOSHttpClient.Version10
{
    public static class Version10Configurator
    {
        public static void AddVersion10(this IServiceCollection services)
        {
            services.AddSingleton<GetAllProjectsQuery>();
            services.AddHttpClient<GitHubClient>("GitHubClient.Version10", x => { x.BaseAddress = new Uri(GitHubConstants.ApiBaseUrl); });
            services.AddSingleton<GitHubClientFactory>();
            services.AddSingleton<Utf8JsonSerializer>();
        }
    }
}
