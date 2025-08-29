using Leasing.Application.Queries;
using Leasing.Application.Repositories;
using Leasing.Infrastructure.Data;
using Leasing.Infrastructure.Data.Repositories;
using Leasing.Infrastructure.QueryHandler;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leasing.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLeasingInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<LeasingDBContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsHistoryTable("_EFMigrationsHistory", "Leasing"));
            });


            //Repositories
            services.AddScoped<IBuildingRepository, BuildingRepository>();
            services.AddScoped<IUnitReposirtory, UnitRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Queries
            services.AddScoped<IBuildingQueries, BuildingQueries>();
            services.AddScoped<IUnitQueries, UnitQueries>();


            return services;
        }
    }
}
