using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DapperWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var hostBuilder = WebHost.CreateDefaultBuilder(args);
            var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;
            var env = services.GetService<IWebHostEnvironment>();

            string appSettings = "";

            if ((env.IsDevelopment() || env.EnvironmentName == "Development" || env.IsEnvironment("Development")
         || env.IsStaging() || env.EnvironmentName == "Staging" || env.IsEnvironment("Staging")
         || env.EnvironmentName == "Testing" || env.IsEnvironment("Testing")
         || env.EnvironmentName == "QA" || env.IsEnvironment("QA")
         || env.EnvironmentName == "QALive" || env.IsEnvironment("QALive")
         || env.EnvironmentName == "Demo" || env.IsEnvironment("Demo")
         || System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Demo"
         || System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "QA"
         || System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "QALive"
         || System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Testing"
         || System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Staging"
         || System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development"))

            {
                appSettings = "appsettings.Development.json";
            }
            else
            {
                appSettings = "appsettings.Production.json";
            }

            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(appSettings, optional: true)
            .AddCommandLine(args)
            .Build();
            hostBuilder.UseConfiguration(config);

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
               Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
               });
    }
}
