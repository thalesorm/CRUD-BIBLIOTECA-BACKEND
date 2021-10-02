using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Configure
{
    public static class DatabaseConfig
    {
        private static StreamWriter _logStream = new StreamWriter("C:\\Log\\log.txt", append: true);

        public static void AddDatabaseConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConexaoDB"))
                    .LogTo(_logStream.WriteLine));
        }
    }
}
