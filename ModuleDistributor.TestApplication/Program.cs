using ModuleDistributor.Serilog;
using Serilog.Events;
using Serilog;

namespace ModuleDistributor.TestApplication
{
    public class Program
    {
        [Serilog]
        public static async Task<int> Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            await builder.ConfigureServiceAsync<TestApplicationModule>();
            var app = builder.Build();
            await app.OnApplicationInitializationAsync();
            await app.RunAsync();
            return 0;
        }
    }
}