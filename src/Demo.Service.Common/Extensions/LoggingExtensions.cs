using Microsoft.Extensions.Configuration;
using Serilog;
using System;

namespace Demo.Service.Common
{
    public static class Logging
    {
        public static void Setup(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.WithProperty("AppName", MicroServiceContext.Name)
                .Enrich.WithProperty("AppVersion", MicroServiceContext.Version)
                .Enrich.WithProperty("EnvName", MicroServiceContext.EnvironmentName)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Seq(configuration.GetSeqUrl())
                .CreateLogger();
        }

        public static void LogStarting()
        {
            Log.Information("Starting: {AppName} v{AppVersion} in {EnvName}", MicroServiceContext.Name, MicroServiceContext.Version, MicroServiceContext.EnvironmentName);
        }

        public static void LogStopping()
        {
            Log.Information("Stopping: {AppName} v{AppVersion} in {EnvName}", MicroServiceContext.Name, MicroServiceContext.Version, MicroServiceContext.EnvironmentName);
        }

        public static void LogCrashed(Exception ex)
        {
            Log.Information(ex, "Crashed: {AppName} v{AppVersion} in {EnvName}", MicroServiceContext.Name, MicroServiceContext.Version, MicroServiceContext.EnvironmentName);
        }
    }
}