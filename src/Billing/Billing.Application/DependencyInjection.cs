using Billing.Application.Commands;
using Billing.Application.CommnadHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace Billing.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBillingApplication(this IServiceCollection services)
        {
            services.AddScoped<IPaymentCommands, PaymentCommands>();

            return services;
        }
    }
}
