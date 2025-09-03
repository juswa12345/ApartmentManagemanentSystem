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
            services.AddScoped<IUnitReposirtory, UnitRepository>();
            services.AddScoped<ITenantRepository, TenantRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();   
            services.AddScoped<ILeasingRepository, LeasingRepository>();

            //Queries
            services.AddScoped<IUnitQueries, UnitQueries>();
            services.AddScoped<ITenantQueries, TenantQueries>();


            return services;
        }
    }
}
