using InTime.Keys.Domain.Common;
using InTime.Keys.Domain.Common.DomainEvents;
using InTime.Keys.Domain.Enumerations;
using System.Runtime.CompilerServices;

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
}