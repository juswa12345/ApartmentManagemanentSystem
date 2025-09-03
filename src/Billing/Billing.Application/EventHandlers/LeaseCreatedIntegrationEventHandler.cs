using Billing.Application.Commands;
using Leasing.IntegrationEvent;
using MediatR;

namespace Billing.Application.EventHandler
{
    public class LeaseCreatedIntegrationEventHandler : INotificationHandler<LeaseCreatedIntegrationEvent>
    {
        private readonly IPaymentCommands _paymentCommands;

        public LeaseCreatedIntegrationEventHandler(IPaymentCommands paymentCommands)
        {
            _paymentCommands = paymentCommands;
        }

        public async Task Handle(LeaseCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await _paymentCommands.ProcessPaymentAsync(notification.TenantId, notification.UnitId, (decimal)notification.Amount);
        }
    }
}
