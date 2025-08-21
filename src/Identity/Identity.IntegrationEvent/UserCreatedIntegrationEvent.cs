using ApartmentManagementSystem.SharedKernel;

namespace Identity.IntegrationEvent
{
    public record UserCreatedIntegrationEvent(Guid Id, string Email, string fullName) : IIntegrationEvent;
    
}
