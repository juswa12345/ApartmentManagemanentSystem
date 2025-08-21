using ApartmentManagementSystem.SharedKernel;

namespace ApartmentManagementSystem.Contracts.Services
{
    public interface IDomainEventPublisher
    {
        Task PublishAsync(IEnumerable<IDomainEvent> domainEvents, CancellationToken cancellationToken);
    }
}
