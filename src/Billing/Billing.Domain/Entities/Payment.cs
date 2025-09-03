using Billing.Domain.ValueObjects;
using System.Diagnostics.Contracts;

namespace Billing.Domain.Entities
{
    public class Payment
    {
        public PaymentId Id { get; private set; }
        public TenantId TenantID { get; private set; } = null!;
        public UnitId UnitID { get; private set; } = null!;
        public double Amount { get; private set; }
        public DateTimeOffset DateOfPayment { get; private set; }
        public DateTimeOffset? NextDuePaymentDate { get; private set; }
        public double NextDueAmountToPay { get; private set; }
        public bool isNextDuePaid { get; private set; }

        private Payment(PaymentId id, double amount, DateTimeOffset dateOfPayment, DateTimeOffset? nextDuePaymentDate)
        {
            Id = id;
            Amount = amount;
            DateOfPayment = dateOfPayment;
            NextDuePaymentDate = nextDuePaymentDate;
            NextDueAmountToPay = amount;
        }

        public void MarkDuePaymentAsPaid()
        {
            NextDueAmountToPay = 0;
            isNextDuePaid = true;
        }

        public static Payment Create(Guid tenantId, Guid unitId, double amount, DateTimeOffset dateOfPayment, DateTimeOffset? nextDuePaymentDate)
        {
            return new Payment(new PaymentId(Guid.NewGuid()), amount, dateOfPayment, nextDuePaymentDate)
            { 
                TenantID = new TenantId(tenantId),
                UnitID = new UnitId(unitId)
            };
        }

    }
}
