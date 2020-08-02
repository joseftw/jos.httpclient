using JOSHttpClient.Version0;
using JOSHttpClient.Version1;
using JOSHttpClient.Version2;
using JOSHttpClient.Version3;
using JOSHttpClient.Version4;
using JOSHttpClient.Version5;
using JOSHttpClient.Version6;
using JOSHttpClient.Version7;
using JOSHttpClient.Version8;
using JOSHttpClient.Version9;
using JOSHttpClient.Version10;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JOS.HttpClient.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddVersion0();
            services.AddVersion1();
            services.AddVersion2();
            services.AddVersion3();
            services.AddVersion4();
            services.AddVersion5();
            services.AddVersion6();
            services.AddVersion7();
            services.AddVersion8();
            services.AddVersion9();
            services.AddVersion10();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
