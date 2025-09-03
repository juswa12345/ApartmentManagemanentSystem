using Billing.Application.Repositories;
using Billing.Infrastructure.Data;
using Billing.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Billing.Infrastructure
{
    public static class DepencyInjection
    {
        public static IServiceCollection AddBillingInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BillingDBContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsHistoryTable("_EFMigrationsHistory", "Billing"));
            });

            services.AddScoped<IPaymentRepository, PaymentRepository>();

            return services;
        }
    }
}
