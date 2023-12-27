using InTime.Keys.Domain.Common.DomainEvents.KeyTransferEvents;
using MediatR;

namespace InTime.Keys.Infrastructure.DomainEventHandlers.SendKeyTransferEmail;

public class KeyTransferCreatedEventHandler : INotificationHandler<KeyTransferCreatedEvent>
{
    
    public Task Handle(KeyTransferCreatedEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
