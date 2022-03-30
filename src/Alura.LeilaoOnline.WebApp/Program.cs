using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Alura.LeilaoOnline.WebApp.Seeding;

namespace Alura.LeilaoOnline.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DatabaseGenerator.Seed();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
