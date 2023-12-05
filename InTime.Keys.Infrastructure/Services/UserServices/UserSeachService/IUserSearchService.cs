using InTime.Keys.Infrastructure.Refit.AccountModels;

namespace InTime.Keys.Infrastructure.Services.UserServices.UserSeachService;

public interface IUserSearchService
{
    Task<AccountProfile> GetUserById(Guid id);
    Task<List<UserShortModel>> GetUserListByNamePart(string part);
}
