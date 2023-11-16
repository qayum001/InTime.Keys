namespace InTime.Keys.Domain.Common.DomainEvents.BidEvents;

public class BidDeniedDomainEvent : BaseEvent
{
    public Guid BookerId { get; }
    public string? Message { get; }
    public BidDeniedDomainEvent(Guid bookerId, string? message = "")
    {
        BookerId = bookerId;
        Message = message;
    }
}