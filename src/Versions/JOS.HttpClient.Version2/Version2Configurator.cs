using Microsoft.Extensions.DependencyInjection;

namespace JOSHttpClient.Version2
{
    public static class Version2Configurator
    {
        public static void AddVersion2(this IServiceCollection services)
        {
            services.AddSingleton<GetAllProjectsQuery>();
            services.AddSingleton<GitHubClient>();
        }
    }
}
