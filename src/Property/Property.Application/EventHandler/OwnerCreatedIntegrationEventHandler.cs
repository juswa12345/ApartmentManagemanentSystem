using Identity.IntegrationEvent;
using MediatR;
using Property.Application.Commnds;

namespace Property.Application.EventHandler
{
    public class OwnerCreatedIntegrationEventHandler : INotificationHandler<OwnerCreatedIntegrationEvent>
    {
        private readonly IOwnerCommands _ownerCommands;

        public OwnerCreatedIntegrationEventHandler(IOwnerCommands ownerCommands)
        {
            _ownerCommands = ownerCommands;
        }

        public async Task Handle(OwnerCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await _ownerCommands.AddOwnerAsync(notification.Id, notification.FullName.FirstName, notification.FullName.LastName, notification.email, notification.contactNumber, notification.gender, notification.age, notification.Address.Street, notification.Address.City, notification.Address.State, notification.Address.ZipCode );
        }
    }
}
