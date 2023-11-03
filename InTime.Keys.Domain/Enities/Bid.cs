using InTime.Keys.Domain.Common;
using InTime.Keys.Domain.Enumerations;

namespace InTime.Keys.Domain.Enities;

public sealed class Bid : BaseAuditableEntity
{
    public User User { get; private set; }
    public TimeSlot TimeSlot { get; private set; }
    public Key Key { get; private set; }
    public BidStatus BidStatus { get; private set; }
    public Bid(Guid id, User user, TimeSlot timeSlot, Key key, BidStatus bidStatus)
        : base(id)
    {
        User = user;
        TimeSlot = timeSlot;
        Key = key;
        BidStatus = bidStatus;
    }
}