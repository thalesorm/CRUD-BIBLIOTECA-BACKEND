using Data.Repository;
using Domain.Interface;
using Microsoft.Extensions.DependencyInjection;
using Service.Service;
using System;

namespace Ioc
{
    public static class Injector
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }
}
