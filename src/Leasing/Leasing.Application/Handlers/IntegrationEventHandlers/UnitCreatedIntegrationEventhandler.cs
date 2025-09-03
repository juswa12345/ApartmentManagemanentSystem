using Leasing.Application.Commands;
using MediatR;
using Property.IntegrationEvent;

namespace Leasing.Application.EventHandler.IntegrationEvents
{
    public class UnitCreatedIntegrationEventhandler : INotificationHandler<UnitCreatedIntegrationEvent>
    {
        private readonly IUnitCommands _unitCommands;

        public UnitCreatedIntegrationEventhandler(IUnitCommands unitCommands)
        {
            _unitCommands = unitCommands;
        }

        public async Task Handle(UnitCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await _unitCommands.AddUnitAsync(notification.UnitId, "", notification.UnitNumber, notification.floor, notification.MonthlyRent, notification.occupancy);
        }
    }
}
