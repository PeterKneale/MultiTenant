using Demo.Service.Common;

namespace Demo.Service.Widgets
{
    public class Program
    {
        public static int Main(string[] args) => MicroService.Run<Startup>(args);
    }
}