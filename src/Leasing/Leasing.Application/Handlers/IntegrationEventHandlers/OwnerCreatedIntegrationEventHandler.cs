using Identity.IntegrationEvent;
using Leasing.Application.Commands;
using MediatR;

namespace Leasing.Application.EventHandler.IntegrationEvents
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
            await _ownerCommands.AddOwnerAsync(notification.Id, notification.FullName.FirstName, notification.FullName.LastName, notification.email, notification.contactNumber);
        }
    }
}
