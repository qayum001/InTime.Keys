using InTime.Keys.Domain.Common;

namespace InTime.Keys.Domain.Enities;

public class User : BaseAuditableEntity
{
    public User(Guid id) : base(id)
    {
    }
}
