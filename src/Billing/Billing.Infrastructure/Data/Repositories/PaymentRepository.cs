using Billing.Application.Repositories;
using Billing.Domain.Entities;

namespace Billing.Infrastructure.Data.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly BillingDBContext _billingDBContext;

        public PaymentRepository(BillingDBContext billingDBContext)
        {
            _billingDBContext = billingDBContext;
        }
        public async Task CreatePaymentAsync(Payment payment)
        {
            await _billingDBContext.Payments.AddAsync(payment);
            await _billingDBContext.SaveChangesAsync();
        }
    }
}
