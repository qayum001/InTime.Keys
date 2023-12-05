using InTime.Keys.Infrastructure.Refit.AccountClientConfigurations;
using InTime.Keys.Infrastructure.Refit.AccountModels;
using MediatR;
using System.Net.Http.Headers;
using System.Web;
namespace InTime.Keys.Infrastructure.Services.UserServices.UserSeachService;

public class UserSearchService : IUserSearchService
{
    private readonly AccountClient _accountClient;
    private readonly HttpClient _httpClient;

    public UserSearchService()
    {
        _httpClient = new HttpClient(new MessageLogHandler());

        _accountClient = new AccountClient(_httpClient);
    }

    public async Task<AccountProfile> GetUserById(Guid id)
    {
        var res = await _accountClient.GetProfile(id);

        return res;
    }

    public async Task<List<UserShortModel>> GetUserListByNamePart(string part)
    {
        var res = await _accountClient.GetProfile(part);

        return res;
    }
}
