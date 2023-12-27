using InTime.Keys.Domain.Enities;

namespace InTime.Keys.Domain.Common.DomainEvents.KeyTransferEvents;

public class KeyTransferCreatedEvent : BaseEvent
{
    public KeyTransfer KeyTransfer { get; }

    public KeyTransferCreatedEvent(KeyTransfer keyTransfer)
    {
        KeyTransfer = keyTransfer;
    }
}
