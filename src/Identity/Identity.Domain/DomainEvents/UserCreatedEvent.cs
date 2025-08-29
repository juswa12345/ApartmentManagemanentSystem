using ApartmentManagementSystem.SharedKernel;
using Identity.Domain.Entities;

namespace Identity.Domain.DomainEvents
{
    public record UserCreatedEvent(Account Account) : IDomainEvent
    {

    };
}
