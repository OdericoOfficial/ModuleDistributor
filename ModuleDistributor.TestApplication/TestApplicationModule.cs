using Microsoft.AspNetCore.Builder;
using ModuleDistributor.Serilog;
using ModuleDistributor.Swagger;

namespace ModuleDistributor.TestApplication
{
    [DependsOn(typeof(SerilogModule),
        typeof(SwaggerModule))]
    public class TestApplicationModule : CustomModule
    {
        public override void ConfigureServices(ServiceContext context)
        {
            context.Services.AddControllers();
        }

        public override void OnApplicationInitialization(ApplicationContext context)
        {
            context.App.UseAuthorization();
            context.EndPoint.MapControllers();
        }
    }
}
