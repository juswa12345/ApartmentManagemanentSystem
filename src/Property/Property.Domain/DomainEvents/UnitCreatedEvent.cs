using ApartmentManagementSystem.SharedKernel;
using Property.Domain.Entities;

namespace Property.Domain.DomainEvents
{
    public record UnitCreatedEvent(Unit Unit, string buildingName) : IDomainEvent;
}
