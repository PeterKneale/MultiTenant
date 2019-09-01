using System;
using System.Reflection;

namespace Demo.Service.Common
{
    internal class MicroServiceContext
    {
        public static Assembly Assembly => Assembly.GetEntryAssembly();
        public static string Name => Assembly.GetName().Name;
        public static string Version => Assembly.GetCustomAttribute<AssemblyFileVersionAttribute>().Version;
        public static string ApiVersion => "v1";
        public static string EnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    }
}