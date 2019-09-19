using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace JOS.HttpClient.GitHubDummyApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await GitHubRepositoriesProvider.Initialize();
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseKestrel(options =>
                {
                    options.AllowSynchronousIO = true;
                })
                .UseUrls("http://localhost:5555")
                .ConfigureAppConfiguration((hostingContext, config) => {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddCommandLine(args);
                })
                .UseStartup<Startup>();
        }
    }
}
