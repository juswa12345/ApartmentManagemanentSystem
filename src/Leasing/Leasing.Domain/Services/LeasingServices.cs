using ApartmentManagementSystem.SharedKernel.Enums;
using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Services
{
    public class LeasingServices
    {
        public LeasingRecord CreateLease(Unit unit, Tenant tenant, Owner owner)
        {
            unit.IncreaseOccupancy();

            if(unit.CurrentOccupancy == unit.OccupancyLimit)
            {
                unit.SetUnitStatus(UnitStatus.Occupied);
            }

            unit.Touch();

            return LeasingRecord.Create(
                tenant.Id,
                owner.Id,
                unit.Id,
                DateTimeOffset.UtcNow,
                Money.From(Convert.ToDecimal(unit.MonthlyRent ?? 0), "PHP"),
                DateTimeOffset.UtcNow.AddYears(1)
                );
        }
    }
}
