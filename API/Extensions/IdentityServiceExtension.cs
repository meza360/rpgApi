using System.Text;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
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

            //Signing key for JWTs
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secret key token"));

            //Adds Token services to container
            services.AddScoped<TokenService>();
            //Adds authentications methods to main container
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(
            options => {
                options.TokenValidationParameters = new TokenValidationParameters{
                    ValidateIssuerSigningKey = true, //Validates key is the same as below
                    IssuerSigningKey = key, //Key to be confronted
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            }
            );

            return services;
        }
    }
}