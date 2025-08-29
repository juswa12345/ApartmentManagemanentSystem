using Leasing.Domain.Enums;
using Leasing.Domain.ValueObjects;
using System.Diagnostics;

namespace Leasing.Domain.Entities
{
    public class Unit
    {
        public UnitId Id { get; private set; }
        public BuildingId BuildingId { get; private set; } = default!;
        public Building Building { get; private set; } = default!;
        public string UnitNumber { get; private set; }
        public int Floor { get; private set; }
        public UnitStatus Status { get; private set; } = UnitStatus.Vacant;
        public double? MonthlyRent { get; private set; }     
        public int? OccupancyLimit { get; private set; }

        public DateTimeOffset? CreatedAt { get; private set; } 
        public DateTimeOffset? UpdatedAt { get; private set; } 

        private  Unit(UnitId id, string unitNumber, int floor)
        {
            Id = id;
            UnitNumber = string.IsNullOrWhiteSpace(unitNumber) ? throw new ArgumentException("Unit number is required.") : unitNumber.Trim();
            Floor = floor;
        }

        public static Unit Create(Building building, string unitNumber, int floor, double monthlyRent, int occupancy)
        {
            var unit = new Unit(new UnitId(Guid.NewGuid()), unitNumber, floor)
            {
                CreatedAt = DateTimeOffset.UtcNow,
                MonthlyRent = monthlyRent,
                OccupancyLimit = occupancy,
                Building = building,
                BuildingId = building.Id
            };

            return unit;
        }

        public void Update(
            BuildingId buildingId, string unitNumber, int floor,
            UnitStatus? status = null, double? monthlyRent = null, 
            int? occupancyLimit = null)
        {
            BuildingId = buildingId;
            UnitNumber = string.IsNullOrWhiteSpace(unitNumber) ? throw new ArgumentException("Unit number is required.") : unitNumber.Trim();
            Floor = floor;

            if (status.HasValue) Status = status.Value;
            MonthlyRent = monthlyRent is < 0 ? throw new ArgumentOutOfRangeException(nameof(monthlyRent)) : monthlyRent;
            if (occupancyLimit is < 0) throw new ArgumentOutOfRangeException(nameof(occupancyLimit));
            OccupancyLimit = occupancyLimit;

            Touch();
        }

        public void ChangeStatus(UnitStatus newStatus) { Status = newStatus; Touch(); }
        public void Touch() => UpdatedAt = DateTimeOffset.UtcNow;
    }
}
