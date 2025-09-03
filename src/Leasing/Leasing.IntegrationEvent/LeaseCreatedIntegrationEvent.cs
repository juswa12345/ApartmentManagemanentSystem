using ApartmentManagementSystem.SharedKernel;

namespace Leasing.IntegrationEvent
{
    public record LeaseCreatedIntegrationEvent(Guid TenantId, Guid OwnerId, Guid UnitId, double Amount, DateTimeOffset LeaseStartDate, DateTimeOffset? LeaseEndDate) : IIntegrationEvent;
}
