using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModuleDistributor.Dapr;
using ModuleDistributor.EventBus.Abstractions;

namespace ModuleDistributor.EventBus.Dapr
{
    [DependsOn(typeof(DaprModule))]
    public class DaprEventModule : CustomModule
    {
        public override void ConfigureServices(ServiceContext context)
            => context.Services.AddScoped<IEventBus, DaprEventBus>();

        public override void OnApplicationInitialization(ApplicationContext context)
        {
            context.App.UseCloudEvents();
            context.EndPoint.MapSubscribeHandler();
        }
    }
}
