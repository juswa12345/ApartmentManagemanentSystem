using ApartmentManagementSystem.SharedKernel;
using ApartmentManagementSystem.SharedKernel.Enums;
using ApartmentManagementSystem.SharedKernel.ValueObjects;

namespace Identity.IntegrationEvent
{
    public record OwnerCreatedIntegrationEvent(Guid Id, PersonName FullName, string email, string contactNumber, Gender gender, int age, Address Address) : IIntegrationEvent;
}
