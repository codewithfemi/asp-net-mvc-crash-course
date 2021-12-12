using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Infrastructure.Data.EF;
using WebApplication.Infrastructure.Data.EF.Seeding;
using WebApplication3.Core.Models;

namespace WebApplication3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            Seed(host).Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static IHost Seed(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                var seedSettingOptions = scope.ServiceProvider.GetService<IOptions<SeedSettings>>();
                UserIdentitySeed.Seed(context, seedSettingOptions.Value.Password);
            }
            return host;
        }
    }
}
