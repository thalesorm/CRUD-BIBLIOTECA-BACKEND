using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Configure
{
    public static class DatabaseConfig
    {

        public static void AddDatabaseConfig(this IServiceCollection services, IConfiguration configuration)
        {
            if (!Directory.Exists("C:\\Log"))
            {
                Directory.CreateDirectory("C:\\Log");
            }
        StreamWriter _logStream = new StreamWriter("C:\\Log\\log.txt", append: true);

        services.AddDbContext<SqlContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConexaoDB"))
                    .LogTo(_logStream.WriteLine));
        }
    }
}
