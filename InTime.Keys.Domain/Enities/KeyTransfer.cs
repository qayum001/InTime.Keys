using InTime.Keys.Domain.Common;
using InTime.Keys.Domain.Common.DomainEvents.KeyTransferEvents;

namespace InTime.Keys.Domain.Enities;

public class KeyTransfer : BaseAuditableEntity
{
    public Guid SenderId { get; private set; }
    public Guid ReceiverId { get; private set; }
    public Guid KeyId { get; private set; }
    public string TransferHash { get; private set; }
    public DateTime ExpireDate { get; private set; }
    public TimeSlot TimeSlot { get; private set; }

    public static KeyTransfer Create( Guid senderId, Guid receiverId, Guid keyId, string transferHash, TimeSlot timeSlot, DateTime expireDate)
    {
        var keyTransfer = new KeyTransfer()
        {
            Id = Guid.NewGuid(),
            SenderId = senderId,
            ReceiverId = receiverId,
            KeyId = keyId,
            TimeSlot = timeSlot,
            ExpireDate = expireDate,
            TransferHash = transferHash
        };

        var keyTransferEvent = new KeyTransferCreatedEvent(keyTransfer);
        keyTransfer.AddDomainEvent(keyTransferEvent);

        return keyTransfer;
    }

    protected KeyTransfer() { }
}
