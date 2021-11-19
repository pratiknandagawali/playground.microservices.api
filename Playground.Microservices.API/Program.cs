namespace Playground.Microservices.API
{
    using Playground.Microservices.API.Extensions;
    using Playground.Microservices.API.MigrationExtension;
    using Playground.Microservices.API.Repositories.EntityFramework;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    public class Program
    {
        public static void Main(string[] args) =>
            CreateHostBuilder(args).Build().LogAndRun(host =>
            {
                var services = host.Services;
                services.GetRequiredService<IDatabaseMigrationService>().Migrate<ApplicationDbContext>();
            });

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
