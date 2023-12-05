namespace InTime.Keys.Infrastructure.Refit.AccountModels;

public class ProfilePaginationRequestResult
{
    public List<UserShortModel> Profiles { get; set; }
    public PageInfo PageInfo { get; set; }
}
