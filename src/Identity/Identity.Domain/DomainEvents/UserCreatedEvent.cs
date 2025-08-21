using ApartmentManagementSystem.SharedKernel;
using Identity.Domain.Entities;

namespace Identity.Domain.DomainEvents
{
    public record UserCreatedEvent(User User) : IDomainEvent;
}
