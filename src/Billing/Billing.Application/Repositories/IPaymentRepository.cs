using Billing.Domain.Entities;

namespace Billing.Application.Repositories
{
    public interface IPaymentRepository
    {
        Task CreatePaymentAsync(Payment payment);
    }
}
