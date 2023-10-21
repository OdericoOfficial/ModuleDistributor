using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ModuleDistributor.SignalR
{
    public class SignalRModule<TEntryModule> : CustomModule
        where TEntryModule : CustomModule
    {
        public override void ConfigureServices(ServiceContext context)
            => context.Services.AddSignalR();

        public override void OnApplicationInitialization(ApplicationContext context)
        {
            Assembly assembly = typeof(TEntryModule).Assembly;
            Type type = typeof(Hub);
            List<Expression> list = new List<Expression>();
            List<ParameterExpression> variables = new List<ParameterExpression>();
            var param1 = Expression.Parameter(typeof(HubEndpointRouteBuilderExtensions));
            var param2 = Expression.Parameter(typeof(IEndpointRouteBuilder));


            foreach (var item in assembly.GetTypes())
                if (item.IsSubclassOf(type))
                {
                    PatternAttribute? attribute = item.GetCustomAttribute<PatternAttribute>();
                    if (attribute is not null)
                    {
                        var variable = Expression.Variable(typeof(string), attribute.Pattern);
                        variables.Add(variable);
                        list.Add(Expression.Call(param1, "MapHub", new Type[] { item }, param2, variable));
                    }
                    else
                    {
                        var variable = Expression.Variable(typeof(string), GetDefalutPattern(item));
                        variables.Add(variable);
                        list.Add(Expression.Call(param1, "MapHub", new Type[] { item }, param2, variable));
                    }
                }

            Expression.Lambda<Action<IEndpointRouteBuilder>>(Expression.Block(list), param2)
                .Compile()
                .Invoke(context.EndPoint);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string GetDefalutPattern(Type type)
        {
            string name = type.Name;
            return name.Substring(0, name.Length - name.IndexOf("Hub") + 1).ToLower();
        }
    }
}