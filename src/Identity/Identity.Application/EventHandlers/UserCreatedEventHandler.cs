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
            //Side effect 
            //Email
            //Logs
            //OTP 
            var integrationEvent = new UserCreatedIntegrationEvent(
                notification.User.Id.Value,
                notification.User.Email,
                notification.User.FullName);

            await _eventBus.PublishAsync(integrationEvent, cancellationToken);
        }
    }
}