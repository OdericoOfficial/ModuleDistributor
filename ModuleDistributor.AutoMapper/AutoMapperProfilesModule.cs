using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ModuleDistributor.AutoMapper
{
    public class AutoMapperProfilesModule<TWrapper> : CustomModule where TWrapper : ProfileCollectionWrapper, new()
    {
        public override void ConfigureServices(ServiceContext context)
            => context.Services.AddAutoMapper(new TWrapper().Profiles);
    }
}