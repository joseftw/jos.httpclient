using Microsoft.Extensions.DependencyInjection;

namespace JOSHttpClient.Version1
{
    public static class Version1Configurator
    {
        public static void AddVersion1(this IServiceCollection services)
        {
            services.AddSingleton<GetAllProjectsQuery>();
            services.AddSingleton<GitHubClient>();
        }
    }
}
