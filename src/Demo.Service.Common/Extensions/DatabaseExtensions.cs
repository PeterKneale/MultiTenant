using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Data.SqlClient;

namespace Demo.Service.Common
{
    public static class DatabaseExtensions
    {
        public static void UseDatabase(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                var log = scope.ServiceProvider.GetRequiredService<ILoggerFactory>().CreateLogger("db");

                var masterConnection = configuration.GetMasterSqlConnectionString();
                var dbConnection = configuration.GetSqlConnectionString();
                var dbName = configuration.GetSqlDatabaseName();
                var dbServer = configuration.GetSqlServerName();

                log.LogInformation($"Database Connection: {dbConnection}");

                var retryAttempts = 30;
                var retryInterval = 1000;
                var sql = $"IF NOT EXISTS(SELECT name FROM master.dbo.sysdatabases WHERE name = N'{dbName}') CREATE DATABASE [{dbName}]";
                Policy
                    .Handle<Exception>()
                    .WaitAndRetry(
                        retryAttempts,
                        retryAttempt => TimeSpan.FromMilliseconds(retryInterval),
                        (exception, timeSpan, retryCount, context) =>
                            log.LogWarning($"Retry {retryCount} encountered error {exception.Message}. Delaying {timeSpan.TotalMilliseconds}ms"))
                    .Execute(() =>
                    {
                        using (var conn = new SqlConnection(masterConnection))
                        using (var cmd = new SqlCommand(sql, conn))
                        {
                            log.LogInformation("Connecting to {dbServer}", dbServer);
                            conn.Open();
                            log.LogInformation("Creating database {dbName} on {dbServer}", dbName, dbServer);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    });
            }
        }

        public static void UseDatabaseMigrations(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var migrator = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
                migrator.MigrateUp();
            }
        }
    }
}