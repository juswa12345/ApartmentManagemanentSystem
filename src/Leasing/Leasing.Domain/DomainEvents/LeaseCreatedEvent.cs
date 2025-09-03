using ApartmentManagementSystem.SharedKernel;
using Leasing.Domain.Entities;

namespace Leasing.Domain.DomainEvents
{
    public record LeaseCreatedEvent(LeasingRecord Record) : IDomainEvent
    {
    }
}
