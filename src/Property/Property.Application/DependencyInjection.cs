using Microsoft.Extensions.DependencyInjection;
using Property.Application.CommandHandlers;
using Property.Application.Commnds;

namespace Property.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPropertyApplication(this IServiceCollection services)
        {
            services.AddScoped<IBuildingCommands, BuildingCommands>();
            services.AddScoped<IUnitCommands, UnitCommands>();
            services.AddScoped<IOwnerCommands, OwnerCommands>();

            return services;
        }
    }
}
