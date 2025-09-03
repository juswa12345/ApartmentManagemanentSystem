using Billing.Domain.Entities;

namespace Billing.Domain.Services
{
    public class BillingServices
    {
        public Payment CreatePaymentReceipt(Guid tenant, Guid unit, double amount)
        {
            return Payment.Create(tenant, unit, amount, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddMonths(1));
        }
    }
}
