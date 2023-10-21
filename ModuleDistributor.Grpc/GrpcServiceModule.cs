using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModuleDistributor.Grpc
{
    [DependsOn(typeof(GrpcModule))]
    public class GrpcServiceModule<TEntryModule> : CustomModule
        where TEntryModule : CustomModule
    {
        public override void OnApplicationInitialization(ApplicationContext context)
        {
            Assembly assembly = typeof(TEntryModule).Assembly;
            List<Expression> list = new List<Expression>();
            List<ParameterExpression> variables = new List<ParameterExpression>();
            var param1 = Expression.Parameter(typeof(GrpcEndpointRouteBuilderExtensions));
            var param2 = Expression.Parameter(typeof(IEndpointRouteBuilder));

            foreach (var item in assembly.GetTypes())
                if (item.GetCustomAttribute<GrpcServiceAttribute>() is null)
                    list.Add(Expression.Call(param1, "MapGrpcService", new Type[] { item }, param2));

            Expression.Lambda<Action<IEndpointRouteBuilder>>(Expression.Block(list), param2)
                .Compile()
                .Invoke(context.EndPoint);
        }
    }
}
