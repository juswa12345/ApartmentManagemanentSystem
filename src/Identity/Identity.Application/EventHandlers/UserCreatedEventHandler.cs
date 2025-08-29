using ApartmentManagementSystem.Contracts.Services;
using Identity.Domain.DomainEvents;
using Identity.IntegrationEvent;
using MediatR;

namespace Identity.Application.EventHandlers
{
    public class UserCreatedEventHandler : INotificationHandler<UserCreatedEvent>
    {
        private readonly IEventBus _eventBus;

        public UserCreatedEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            var integrationEvent = new UserCreatedIntegrationEvent(
                notification.Account.Id.Value,
                notification.Account.FullName.FirstName,
                notification.Account.FullName.LastName,
                notification.Account.Email,
                notification.Account.ContactNumber,
                (int)notification.Account.Gender,
                notification.Account.Age,
                notification.Account.Address.Street,
                notification.Account.Address.City,
                notification.Account.Address.State,
                notification.Account.Address.ZipCode);

            await _eventBus.PublishAsync(integrationEvent, cancellationToken);
        }
    }
}