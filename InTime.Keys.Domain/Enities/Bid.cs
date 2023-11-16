using InTime.Keys.Domain.Common;
using InTime.Keys.Domain.Common.DomainEvents.BidEvents;
using InTime.Keys.Domain.Enumerations;

namespace InTime.Keys.Domain.Enities;

public class Bid : BaseAuditableEntity
{
    public Guid UserId { get; private set; }
    public TimeSlot TimeSlot { get; private set; }
    public Key Key { get; private set; }
    public BidStatus BidStatus { get; private set; }

    protected Bid() {}

    public static Bid Create(Guid userId, TimeSlot timeSlot, Key key)
    {
        return new Bid()
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            TimeSlot = timeSlot,
            Key = key,
        };
    }

    public void CloseBid()
    {
        //TODO: сделать добавление ивентов доступным только внутри классов.
        //TODO: добаваить в BidClosedDomainEvent нужные данные(поля)
        AddDomainEvent(new BidClosedDomainEvent());
        BidStatus = BidStatus.Closed;
    }

    public void DenayBid(string? message = "")
    {
        AddDomainEvent(new BidDeniedDomainEvent(UserId, message));
        BidStatus = BidStatus.Denied;
    }

    public void Approve()
    {
        AddDomainEvent(new BidApprovedDomainEvent());
        BidStatus = BidStatus.Approved;
    }
}