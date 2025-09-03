using ApartmentManagementSystem.Contracts.Services;
using MediatR;
using Property.Domain.DomainEvents;
using Property.IntegrationEvent;

namespace Property.Application.EventHandler
{
    public class UnitCreatedEventHandler : INotificationHandler<UnitCreatedEvent>
    {
        private readonly IEventBus _eventBus;

        public UnitCreatedEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(UnitCreatedEvent notification, CancellationToken cancellationToken)
        {
            var integrationEvent = new UnitCreatedIntegrationEvent(
                notification.Unit.Id.Value,
                notification.buildingName,
                notification.Unit.UnitNumber,
                notification.Unit.Floor,
                notification.Unit.Status,
                notification.Unit.MonthlyRent ?? 0,
                notification.Unit.OccupancyLimit ?? 0);

            await _eventBus.PublishAsync(integrationEvent, cancellationToken);
        }
    }
}
