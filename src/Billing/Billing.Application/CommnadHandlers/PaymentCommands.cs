using Billing.Application.Commands;
using Billing.Application.Repositories;
using Billing.Domain.Entities;
using Billing.Domain.Services;

namespace Billing.Application.CommnadHandlers
{
    public class PaymentCommands : IPaymentCommands
    {
        private readonly IPaymentRepository _payment;

        public PaymentCommands(IPaymentRepository payment)
        {
            _payment = payment;
        }
        public async Task ProcessPaymentAsync(Guid tenantId, Guid unitId, decimal amount)
        {
            var BillingServices = new BillingServices();

            Payment payment = BillingServices.CreatePaymentReceipt(tenantId, unitId, Convert.ToDouble(amount));

            await _payment.CreatePaymentAsync(payment);


        }
    }
}
