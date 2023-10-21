using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ModuleDistributor.Grpc;

namespace ModuleDistributor.MagicOnion
{
    [DependsOn(typeof(GrpcModule))]
    public class MagicOnionModule : CustomModule
    {
        public override void ConfigureServices(ServiceContext context)
            => context.Services.AddMagicOnion();

        public override void OnApplicationInitialization(ApplicationContext context)
            => context.EndPoint.MapMagicOnionService();
    }
}