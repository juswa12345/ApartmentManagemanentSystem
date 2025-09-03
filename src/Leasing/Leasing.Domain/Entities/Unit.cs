using ApartmentManagementSystem.SharedKernel.Enums;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Entities
{
    public class Unit
    {
        public UnitId Id { get; private set; }
        public string BuildingName { get; private set; }
        public string UnitNumber { get; private set; }
        public int Floor { get; private set; }
        public UnitStatus Status { get; private set; } = UnitStatus.Vacant;
        public double? MonthlyRent { get; private set; }     
        public int? OccupancyLimit { get; private set; }
        public int CurrentOccupancy { get; set; } = 0;
        public DateTimeOffset? CreatedAt { get; private set; } 
        public DateTimeOffset? UpdatedAt { get; private set; }
        public List<LeasingRecord> LeasingHistory { get; private set; } = [];
        public List<Tenant> tenants { get; private set; } = [];

        private  Unit(UnitId id, string buildingName, string unitNumber, int floor)
        {
            Id = id;
            UnitNumber = unitNumber;
            Floor = floor;
            BuildingName = buildingName;
        }

        public void IncreaseOccupancy()
        {
            if (CurrentOccupancy > OccupancyLimit)
            {
                throw new InvalidOperationException($"Occupancy limit of {OccupancyLimit.Value} exceeded.");
            }

            CurrentOccupancy++;
        }

        public void DecreaseOccupancy()
        {
            if (CurrentOccupancy <= 0)
            {
                throw new InvalidOperationException("Current occupancy is already zero.");
            }
            CurrentOccupancy--;
        }

        public void SetUnitStatus(UnitStatus unitStatus)
        {
            Status = unitStatus;
        }


        public static Unit Create(UnitId Id, string buildingName, string unitNumber, int floor, double monthlyRent, int occupancy)
        {
            var unit = new Unit(Id, buildingName, unitNumber, floor)
            {
                CreatedAt = DateTimeOffset.UtcNow,
                MonthlyRent = monthlyRent,
                OccupancyLimit = occupancy,

            };

            return unit;
        }

        public void Update(string unitNumber, int floor,
            UnitStatus? status = null, double? monthlyRent = null, 
            int? occupancyLimit = null)
        {
            UnitNumber = string.IsNullOrWhiteSpace(unitNumber) ? throw new ArgumentException("Unit number is required.") : unitNumber.Trim();
            Floor = floor;

            if (status.HasValue) Status = status.Value;
            MonthlyRent = monthlyRent is < 0 ? throw new ArgumentOutOfRangeException(nameof(monthlyRent)) : monthlyRent;
            if (occupancyLimit is < 0) throw new ArgumentOutOfRangeException(nameof(occupancyLimit));
            OccupancyLimit = occupancyLimit;

            Touch();
        }
        public void Touch() => UpdatedAt = DateTimeOffset.UtcNow;
    }
}
