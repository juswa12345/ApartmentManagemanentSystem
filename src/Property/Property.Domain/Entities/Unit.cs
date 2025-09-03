using ApartmentManagementSystem.SharedKernel.Entities;
using ApartmentManagementSystem.SharedKernel.Enums;
using Property.Domain.DomainEvents;
using Property.Domain.ValueObjects;

namespace Property.Domain.Entities
{
    public class Unit : Entity
    {
        public UnitId Id { get; private set; }
        public string UnitNumber { get; private set; }
        public BuildingId BuildingId { get; private set; } = null!;
        public Building Building { get; private set; } = null!;
        public int Floor { get; private set; }
        public UnitStatus Status { get; private set; } = UnitStatus.Vacant;
        public double? MonthlyRent { get; private set; }     
        public int? OccupancyLimit { get; private set; }

        public int? CurrentOccupancy { get; set; }
        public DateTimeOffset? CreatedAt { get; private set; } 
        public DateTimeOffset? UpdatedAt { get; private set; }

        private Unit(UnitId id, string unitNumber, int floor)
        {
            Id = id;
            UnitNumber = string.IsNullOrWhiteSpace(unitNumber) ? throw new ArgumentException("Unit number is required.") : unitNumber.Trim();
            Floor = floor;
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

        public static Unit Create(Building building, string unitNumber, int floor, double monthlyRent, int occupancy)
        {
            var unit = new Unit(new UnitId(Guid.NewGuid()),  unitNumber, floor)
            {
                CreatedAt = DateTimeOffset.UtcNow,
                MonthlyRent = monthlyRent,
                OccupancyLimit = occupancy,
                Building = building,
                BuildingId = building.Id
            };

            unit.RaiseDomainEvent(new UnitCreatedEvent(unit, building.Name));

            return unit;
        }

        public void Update(
            string unitNumber, int floor,
            double? monthlyRent = null, 
            int? occupancyLimit = null)
        {
            UnitNumber = string.IsNullOrWhiteSpace(unitNumber) ? this.UnitNumber : unitNumber;
            Floor = floor;
            MonthlyRent = monthlyRent is < 0 ? this.MonthlyRent : monthlyRent;
            OccupancyLimit = occupancyLimit is < 0 ? this.OccupancyLimit:occupancyLimit;

            Touch();
        }

        public void ChangeStatus(UnitStatus newStatus) { Status = newStatus; Touch(); }
        public void Touch() => UpdatedAt = DateTimeOffset.UtcNow;
    }
}
