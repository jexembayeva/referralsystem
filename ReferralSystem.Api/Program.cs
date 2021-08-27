using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ReferralSystem.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom
                .Configuration(configuration, "Logging")
                .CreateLogger();

            try
            {
                WebHost
                    .CreateDefaultBuilder(args)
                    .SuppressStatusMessages(true)
                    .ConfigureAppConfiguration((builderContext, config) =>
                        config
                            .AddJsonFile("appsettings.secrets.json", true, true)
                            .AddJsonFile("/run/secrets/appsettings.json", true, true)
                            .AddEnvironmentVariables())
                    .ConfigureLogging(builder =>
                    {
                        builder
                            .ClearProviders()
                            .AddSerilog(dispose: true);

                        builder.Services.AddTransient<Microsoft.Extensions.Logging.ILogger>(options =>
                            options.GetService<ILogger<object>>());
                    })
                    .UseStartup<Startup>()
                    .UseSerilog()
                    .Build()
                    .Run();
            }
            catch (Exception exception)
            {
                Environment.ExitCode = 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
