using Microsoft.Extensions.DependencyInjection;

namespace JOSHttpClient.Version0
{
    public static class Version0Configurator
    {
        public static void AddVersion0(this IServiceCollection services)
        {
            services.AddSingleton<GetAllProjectsQuery>();
            services.AddSingleton<GitHubClient>();
        }
    }
}
