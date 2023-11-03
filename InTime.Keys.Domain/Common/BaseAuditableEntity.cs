namespace InTime.Keys.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity, IAuditableEntity
{
    protected BaseAuditableEntity(Guid id) : base(id)
    {
    }

    public Guid? CreatedBy { get ; set; }
    public DateTime? CreatedDate { get ; set; }
    public Guid? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
}