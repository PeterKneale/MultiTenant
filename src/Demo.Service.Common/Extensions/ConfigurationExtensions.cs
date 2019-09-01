using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Demo.Service.Common
{
    public static class ConfigurationExtensions
    {
        public static string GetMasterSqlConnectionString(this IConfiguration configuration) =>
            new SqlConnectionStringBuilder(configuration.GetSqlConnectionString()) { InitialCatalog = "master" }.ToString();

        public static string GetSqlDatabaseName(this IConfiguration configuration) =>
            GetConnection(configuration).InitialCatalog;

        public static string GetSqlServerName(this IConfiguration configuration) =>
            GetConnection(configuration).DataSource;

        private static SqlConnectionStringBuilder GetConnection(IConfiguration configuration) =>
            new SqlConnectionStringBuilder(configuration.GetSqlConnectionString());

        public static string GetSqlConnectionString(this IConfiguration configuration) =>
            configuration["ConnectionString"];

        public static string GetSeqUrl(this IConfiguration configuration) =>
            configuration["SeqUrl"];
    }
}