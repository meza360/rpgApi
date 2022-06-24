using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;
using Persistence;

namespace API.Extensions
{
    public static class IdentityServiceExtension
    {
        public static IServiceCollection AddIdentityServiceExtension(this IServiceCollection services, IConfiguration config)
        {
                       services.AddIdentityCore<User>(
                        options => {
                            options.Password.RequireLowercase= true;
                            options.Password.RequireDigit = false;
                            options.Password.RequireUppercase = false;
                            options.Password.RequireNonAlphanumeric = false;
                            options.Password.RequiredLength = 4;
                        }
                       )
                       .AddEntityFrameworkStores<DataContext>()
                       .AddSignInManager<SignInManager<User>>(); 

                       services.AddAuthentication();

                       return services;
        }
    }
}