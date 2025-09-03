using ApartmentManagementSystem.SharedKernel;
using ApartmentManagementSystem.SharedKernel.Enums;

namespace Property.IntegrationEvent
{
    public record UnitCreatedIntegrationEvent(Guid UnitId, string BuildingName,  string UnitNumber, int floor, UnitStatus UnitStatus, double MonthlyRent, int occupancy) : IIntegrationEvent;
}
