using InTime.Keys.Domain.Common;
using InTime.Keys.Domain.Enumerations;

namespace InTime.Keys.Domain.Enities;

public class Bid : BaseAuditableEntity
{
    public Guid UserId { get; private set; }
    public TimeSlot TimeSlot { get; private set; }
    public Key Key { get; private set; }
    public BidStatus BidStatus { get; set; }

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
}