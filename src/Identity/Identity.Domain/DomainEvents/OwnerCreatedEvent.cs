using ApartmentManagementSystem.SharedKernel;
using Identity.Domain.Entities;

namespace Identity.Domain.DomainEvents
{
    public record OwnerCreatedEvent(Account Account) : IDomainEvent
    {

    };
}
