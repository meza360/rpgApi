using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions
{
    public static class OracleServicesExtension
    {
        public static IServiceCollection AddOracleServiceExtension(this IServiceCollection services,IConfiguration config)
        {
            //Sets Connection String for Oracle Services
            services.AddDbContext<DataContext>(
                options => {
                    options.UseOracle(
                        config.GetConnectionString("OracleDevConnection")
                    );
                }
            );
            return services;
        }

       
    }
}