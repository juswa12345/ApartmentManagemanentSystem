using Identity.IntegrationEvent;
using Leasing.Application.Commands;
using MediatR;

namespace Leasing.Application.EventHandler.IntegrationEvents
{
    public class TenantCreatedIntegrationEventHandler : INotificationHandler<TenantCreatedIntegrationEvent>
    {
        private readonly ITenantCommands _tenantCommands;

        public TenantCreatedIntegrationEventHandler(ITenantCommands tenantCommands)
        {
            _tenantCommands = tenantCommands;
        }
        public async Task Handle(TenantCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {
           await _tenantCommands.AddTenantAsync(notification.Id, notification.FullName.FirstName, notification.FullName.LastName, notification.email, notification.contactNumber);
        }
    }
}
