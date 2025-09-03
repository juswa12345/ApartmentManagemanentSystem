using ApartmentManagementSystem.Contracts.Services;
using Identity.Domain.DomainEvents;
using Identity.IntegrationEvent;
using MediatR;

namespace Identity.Application.EventHandlers
{
    public class OwnerCreatedEventHandler : INotificationHandler<OwnerCreatedEvent>
    {
        private readonly IEventBus _eventBus;

        public OwnerCreatedEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(OwnerCreatedEvent notification, CancellationToken cancellationToken)
        {
            var integrationEvent = new OwnerCreatedIntegrationEvent(
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