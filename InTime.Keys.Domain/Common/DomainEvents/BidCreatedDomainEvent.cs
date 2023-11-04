namespace InTime.Keys.Domain.Common.DomainEvents;

public sealed class BidCreatedDomainEvent : BaseEvent
{
    public Guid KeyId { get; }
    public BidCreatedDomainEvent(Guid keyId)
    {
        OccuredDate = DateTime.Now;
        KeyId = keyId;
    }
}
