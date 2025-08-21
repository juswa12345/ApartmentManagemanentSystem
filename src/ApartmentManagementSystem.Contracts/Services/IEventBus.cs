

using ApartmentManagementSystem.SharedKernel;

namespace ApartmentManagementSystem.Contracts.Services
{
    public interface IEventBus
    {
        Task PublishAsync(IIntegrationEvent integrationEvent, CancellationToken cancellationToken);
    }
}
