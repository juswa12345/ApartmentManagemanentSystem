using ApartmentManagementSystem.Contracts.Services;
using Leasing.Domain.DomainEvents;
using Leasing.IntegrationEvent;
using MediatR;

namespace Leasing.Application.EventHandler.DomainEvents
{
    public class LeaseCreatedEventHandler : INotificationHandler<LeaseCreatedEvent>
    {
        private readonly IEventBus _eventBus;

        public LeaseCreatedEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(LeaseCreatedEvent notification, CancellationToken cancellationToken)
        {
            var integrationEvent = new LeaseCreatedIntegrationEvent(
                notification.Record.Id.Value,
                notification.Record.Id.Value,
                notification.Record.Id.Value,
                Convert.ToDouble(notification.Record.MonthlyRent.Amount),
                notification.Record.Term.Start,
                notification.Record.Term.End
                );

            await _eventBus.PublishAsync(integrationEvent, cancellationToken);
        }
    }
}
