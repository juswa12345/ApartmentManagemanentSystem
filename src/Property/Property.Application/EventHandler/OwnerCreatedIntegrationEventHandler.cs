using Identity.IntegrationEvent;
using MediatR;
using Property.Application.Commnds;

namespace Property.Application.EventHandler
{
    public class OwnerCreatedIntegrationEventHandler : INotificationHandler<UserCreatedIntegrationEvent>
    {
        private readonly IOwnerCommands _ownerCommands;

        public OwnerCreatedIntegrationEventHandler(IOwnerCommands ownerCommands)
        {
            _ownerCommands = ownerCommands;
        }

        public async Task Handle(UserCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await _ownerCommands.AddOwnerAsync(notification.Id, notification.firstName, notification.lastName, notification.email, notification.contactNumber, notification.gender, notification.age, notification.street, notification.city, notification.state, notification.zipCode );
        }
    }
}
