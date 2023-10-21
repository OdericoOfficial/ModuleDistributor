using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleDistributor.AutoMapper
{
    public class AutoMapperModule<TProfile> : CustomModule where TProfile : Profile
    {
        public override void ConfigureServices(ServiceContext context)
            => context.Services.AddAutoMapper(typeof(TProfile));
    }

    public class AutoMapperModule<TProfile1, TProfile2> : CustomModule
        where TProfile1 : Profile where TProfile2 : Profile
    {
        public override void ConfigureServices(ServiceContext context)
            => context.Services.AddAutoMapper(typeof(TProfile1), typeof(TProfile2));
    }

    public class AutoMapperModule<TProfile1, TProfile2, TProfile3> : CustomModule
        where TProfile1 : Profile where TProfile2 : Profile where TProfile3 : Profile
    {
        public override void ConfigureServices(ServiceContext context)
            => context.Services.AddAutoMapper(typeof(TProfile1), typeof(TProfile2), typeof(TProfile3));
    }
}
