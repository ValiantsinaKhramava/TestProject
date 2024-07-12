using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace TestProject.Core
{
    public class Configuration
    {
        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.Configure<AppSettings>(context.Configuration.GetSection("AppSettings"));
                services.AddSingleton<AppSettings>(sp =>
                    sp.GetRequiredService<IOptions<AppSettings>>().Value);
            });
    }
}
