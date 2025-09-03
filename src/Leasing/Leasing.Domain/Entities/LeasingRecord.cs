using ApartmentManagementSystem.SharedKernel.Entities;
using Leasing.Domain.DomainEvents;
using Leasing.Domain.Enums;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Entities
{
    public class LeasingRecord : Entity
    {
        public LeasingRecordId Id { get; private set; }
        public TenantId TenantId { get; private set; }
        public Tenant Tenant { get; private set; } = null!;
        public OwnerId OwnerId { get; private set; }
        public Owner Owner { get; private set; } = null!;
        public UnitId UnitId { get; private set; }
        public Unit Unit { get; private set; } = null!;
        public LeaseTerm Term { get; private set; } = null!;
        public Money MonthlyRent { get; private set; } = null!;

        public LeaseStatus Status { get; private set; }

        private LeasingRecord(
            LeasingRecordId id,
            TenantId tenantId,
            OwnerId ownerId,
            UnitId unitId)
        {
            Id = id;
            TenantId = tenantId;
            OwnerId = ownerId;
            UnitId = unitId;
        }

        public static LeasingRecord Create(
            TenantId tenantId,
            OwnerId ownerId,
            UnitId unitId,
            DateTimeOffset leaseStartDate,
            Money monthlyRent,
            DateTimeOffset? leaseEndDate = null)
        {
            var term = LeaseTerm.Create(leaseStartDate, leaseEndDate);


            if (monthlyRent.Amount <= 0) throw new Exception("Monthly rent must be positive.");

            var lease = new LeasingRecord(new LeasingRecordId(Guid.NewGuid()), tenantId, ownerId, unitId) {

                Term = term,
                MonthlyRent = monthlyRent,
                Status = term.End is null ? LeaseStatus.Active : LeaseStatus.Inactive
            };

            lease.RaiseDomainEvent(new LeaseCreatedEvent(lease));

            return lease;
        }

        public void End(DateTimeOffset endDate)
        {
            if (Term.End is not null) throw new Exception("Lease already ended.");
            Term = Term.WithEnd(endDate); 
            Status = LeaseStatus.Inactive;
        }

        public void ChangeMonthlyRent(Money newRent, DateTimeOffset effectiveDate)
        {
            if (newRent is null || newRent.Amount <= 0) throw new Exception("Rent must be positive.");
            MonthlyRent = newRent;
        }

        public void Renew(DateTimeOffset newStart, DateTimeOffset? newEnd)
        {
            if (Term.End is null) throw new Exception("Cannot renew an active lease; end it first or create a new lease.");
            if (newStart <= Term.End) throw new Exception("Renewal must start after prior lease end.");
            Term = LeaseTerm.Create(newStart, newEnd);
            Status = newEnd is null ? LeaseStatus.Active : LeaseStatus.Inactive;
        }
    }

}
