using ApartmentManagementSystem.Contracts.Services;
using Identity.Domain.DomainEvents;
using Identity.IntegrationEvent;
using MediatR;

namespace Identity.Application.EventHandlers
{
    internal class TenantCreatedEventHandler : INotificationHandler<TenantCreatedEvent>
    {
        private readonly IEventBus _eventBus;

        public TenantCreatedEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(TenantCreatedEvent notification, CancellationToken cancellationToken)
        {
            var integrationEvent = new TenantCreatedIntegrationEvent(
                notification.Account.Id.Value,
                notification.Account.FullName,
                notification.Account.Email,
                notification.Account.ContactNumber,
                notification.Account.Gender,
                notification.Account.Age,
                notification.Account.Address);

            await _eventBus.PublishAsync(integrationEvent, cancellationToken);
        }
    }
}
