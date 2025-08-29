using Leasing.Application.CommandHandlers;
using Leasing.Application.Commnds;
using Microsoft.Extensions.DependencyInjection;

namespace Leasing.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLeasingApplication(this IServiceCollection services)
        {
            services.AddScoped<IBuildingCommands, BuildingCommands>();
            services.AddScoped<IUnitCommands, UnitCommands>();

            return services;
        }
    }
}
