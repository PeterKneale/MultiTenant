using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;

namespace Demo.Service.Common
{
    public static class MicroService
    {
        public static int Run<T>(string[] args) where T : class
        {
            try
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .AddEnvironmentVariables()
                    .Build();

                Logging.Setup(config);

                Logging.LogStarting();

                WebHost.CreateDefaultBuilder(args)
                    .UseStartup<T>()
                    .UseSerilog()
                    .UseKestrel()
                    .Build()
                    .Run();

                Logging.LogStopping();

                return 0;
            }
            catch (Exception ex)
            {
                Logging.LogCrashed(ex);
return -1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}