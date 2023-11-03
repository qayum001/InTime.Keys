using InTime.Keys.Domain.Common;

namespace InTime.Keys.Domain.Enities;

public sealed class Key : BaseAuditableEntity
{
    public Guid AudienceId { get; private set; }
    public string AudienceName { get; private set; } = string.Empty;

    public Key(Guid id, Guid audienceId, string audienceName)
        : base(id)
    {
        if (audienceId == Guid.Empty)
            throw new ArgumentException("audience id can not be empty", nameof(audienceId));
        AudienceId = audienceId;
        if (string.IsNullOrEmpty(audienceName))
            throw new ArgumentException("audience name can not be empty", nameof(audienceName));
        AudienceName = audienceName;
    }
}