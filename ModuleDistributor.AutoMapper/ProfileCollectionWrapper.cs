using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleDistributor.AutoMapper
{
    public abstract class ProfileCollectionWrapper
    {
        private readonly List<Type> _profiles = new List<Type>();
        public Type[] Profiles 
            => _profiles.ToArray();

        protected void AddProfile<TProfile>() where TProfile : Profile
            => _profiles.Add(typeof(TProfile));
    }
}
