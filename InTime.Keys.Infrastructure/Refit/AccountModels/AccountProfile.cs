namespace InTime.Keys.Infrastructure.Refit.AccountModels;

public class AccountProfile
{
    public Guid AccountId { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public DateTime BirthDate { get; set; }
    public int Gender { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool IsVerified { get; set; }
    public Guid StuffId { get; set; }
    public string FullName { get; set; }
    public DateTime CreateDateTime { get; set; }
    public string AvatarUrl { get; set; }
}
