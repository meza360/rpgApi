using Persistence;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class SqlLiteServiceExtension
    {
        public static IServiceCollection AddSqlLiteServiceExtension(this IServiceCollection services,IConfiguration config){
            services.AddDbContext<DataContext>(
                options =>{
                    options.UseSqlite(config.GetConnectionString("SqlLiteDevConnection"));
                }
            );
            return services;
        }
    }
}