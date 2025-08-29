using ApartmentManagementSystem.SharedKernel;

namespace Identity.IntegrationEvent
{
    public record UserCreatedIntegrationEvent(Guid Id, string firstName, string lastName, string email, string contactNumber, int gender, int age, string street, string city, string state, string zipCode) : IIntegrationEvent;
    
}
