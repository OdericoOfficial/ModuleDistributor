using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModuleDistributor.GrpcServer
{
    public class GrpcAPIModule<TEntryModule> : CustomModule
        where TEntryModule : CustomModule
    {
        public override void ConfigureServices(ServiceContext context)
            => context.Services.AddGrpc();

        public override void OnApplicationInitialization(ApplicationContext context)
        {
            var param1 = Expression.Parameter(typeof(GrpcEndpointRouteBuilderExtensions));
            var param2 = Expression.Parameter(typeof(IEndpointRouteBuilder));
            Assembly assembly = typeof(TEntryModule).Assembly;

            foreach (var type in assembly.GetTypes())
            {
                foreach (var attribute in type.GetCustomAttributes())
                {
                    GrpcAPIAttribute? grpc = attribute as GrpcAPIAttribute;
                    if (grpc is not null)
                    {
                        var call = Expression.Call(param1, "MapGrpcService", new Type[] { type }, param2);
                        Expression.Lambda(call, param1, param2).Compile().DynamicInvoke(context.EndPoint);
                    }
                }
            }
        }
    }
}
