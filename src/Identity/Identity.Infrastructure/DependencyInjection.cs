using Identity.Application.Queries;
using Identity.Application.Repositories;
using Identity.Application.Services;
using Identity.Domain.Repositories;
using Identity.Infrastructure.Data;
using Identity.Infrastructure.Data.Repositories;
using Identity.Infrastructure.QueryHandlers;
using Identity.Infrastructure.Services;
using Identity.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIdentityInfrastructure(
           this IServiceCollection services,
           IConfiguration configuration)
        {


            services.AddDbContext<IdentityDbContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsHistoryTable("_EFMigrationsHistory", "Identity"));
            });


            var jwtSettings = new JwtSettings();
            configuration.Bind("JwtSettings", jwtSettings);
            services.AddSingleton(jwtSettings);
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSettings.Key))
                    };

                    options.TokenValidationParameters = tokenValidationParameters;
                });

            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            //Services
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<ITokenService, TokenService>();

            //Queries
            services.AddScoped<IAccountQueries, AccountQueries>();


            return services;
        }
    }
}
