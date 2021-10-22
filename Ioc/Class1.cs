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
            services.AddScoped(typeof(ILoanRepository), typeof(LoanRepository));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IUserService), typeof(UserService));


        }
    }
}
