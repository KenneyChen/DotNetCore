using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace _02ServiceDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureAppConfiguration((host, cf) =>
            {
                var defaultSettings = "appsettings.json";
                var CONFIG_ENV = Environment.GetEnvironmentVariable("CONFIG_ENV");
                if (!string.IsNullOrWhiteSpace(CONFIG_ENV))
                {
                    defaultSettings = $"appsettings-{CONFIG_ENV}.json";
                }
                cf.SetBasePath(AppContext.BaseDirectory);
                cf.AddJsonFile(defaultSettings);

            }).ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
