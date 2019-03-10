using System;
using JOSHttpClient.Common;
using Microsoft.Extensions.DependencyInjection;

namespace JOSHttpClient.Version3
{
    public static class Version3Configurator
    {
        public static void AddVersion3(this IServiceCollection services)
        {
            services.AddSingleton<GetAllProjectsQuery>();
            services.AddHttpClient("GitHub", x => { x.BaseAddress = new Uri(GitHubConstants.ApiBaseUrl); });
            services.AddSingleton<GitHubClient>();
        }
    }
}
