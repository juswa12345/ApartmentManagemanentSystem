using Leasing.Application.CommandHandlers;
using Leasing.Application.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Leasing.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLeasingApplication(this IServiceCollection services)
        {
            services.AddScoped<IUnitCommands, UnitCommands>();
            services.AddScoped<ITenantCommands, TenantCommands>();
            services.AddScoped<IOwnerCommands, OwnerCommands>();
            services.AddScoped<ILeasingCommands, LeasingCommands>();

            return services;
        }
    }
}
