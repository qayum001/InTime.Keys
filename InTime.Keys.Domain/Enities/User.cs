using InTime.Keys.Domain.Common;

namespace InTime.Keys.Domain.Enities;

public class User : BaseAuditableEntity
{
    public string FullName { get; private set; }
    public Guid UserId { get; private set; }
    protected User() {}

    public static User Create(string fullName, Guid userId)
    {
        var user = new User()
        {
            Id = Guid.Empty,
            FullName = fullName,
            UserId = userId
        };

        return user;
    }
}
