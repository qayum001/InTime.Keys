namespace InTime.Keys.Infrastructure.Refit.AccountModels;

public class UserShortModel
{
    public string? BirthDate { get; set; }
    public string? VerifyDateTime { get; set; }
    public string? LastOnlineDateTime { get; set; }
    public string? Faculty { get; set; }
    public string? Group { get; set; }
    public string? Phone { get; set; }
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public bool? IsVerified { get; set; }
    public string? Avatar { get; set; }
    public string? Email { get; set; }
}
