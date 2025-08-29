using Identity.Application.CommandHandlers;
using Identity.Application.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIdentityApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationCommands, AuthenticationCommands>();
            services.AddScoped<IAccountCommands, AccountCommands>();
            services.AddScoped<IRoleCommands, RoleCommands>();

            return services;
        }
    }
}