using InTime.Keys.Domain.Common;
using InTime.Keys.Domain.Enumerations;
using System.Runtime.InteropServices;

namespace InTime.Keys.Domain.Enities;

public class Key : BaseAuditableEntity
{
    public Guid AudienceId { get; private set; }
    public string AudienceName { get; private set; } = string.Empty;
    public KeyStatus Status { get; private set; }

    public void SetStatus(KeyStatus status) => Status = status;

    protected Key() {}

    public static Key Create(Guid audienceId, string audienceName)
    {
        if (audienceId == Guid.Empty)
            throw new ArgumentException("audience id can not be empty", nameof(audienceId));
        if (string.IsNullOrEmpty(audienceName))
            throw new ArgumentException("audience name can not be empty", nameof(audienceName));

        return new Key()
        {
            Id = Guid.NewGuid(),
            AudienceId = audienceId,
            AudienceName = audienceName
        };
    }
}