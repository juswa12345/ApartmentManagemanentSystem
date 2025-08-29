using Property.Infrastructure.Data;
using Property.Infrastructure.QueryHandler;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Property.Infrastructure.Data.Repositories;
using Property.Application.Repositories;
using Property.Application.Queries;

namespace Property.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPropertyInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<PropertyDBContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsHistoryTable("_EFMigrationsHistory", "Property"));
            });


            //Repositories
            services.AddScoped<IBuildingRepository, BuildingRepository>();
            services.AddScoped<IUnitReposirtory, UnitRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();

            //Queries
            services.AddScoped<IBuildingQueries, BuildingQueries>();
            services.AddScoped<IUnitQueries, UnitQueries>();


            return services;
        }
    }
}
