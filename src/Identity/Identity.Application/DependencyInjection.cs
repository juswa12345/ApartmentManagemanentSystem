using Identity.Application.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIdentityApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationCommands, AuthenticationCommands>();

            return services;
        }
    }
}