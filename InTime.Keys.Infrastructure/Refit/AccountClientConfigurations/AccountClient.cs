using InTime.Keys.Infrastructure.Refit.AccountModels;
using InTime.Keys.Infrastructure.Refit.Interfaces;
using Refit;
using System.Net.Http.Headers;

namespace InTime.Keys.Infrastructure.Refit.AccountClientConfigurations;


//класс для логирования
public class AccountClient
{
    private readonly IAccountClient _accountClient;
    public AccountClient(HttpClient httpClient)
    {
        httpClient.BaseAddress = new Uri("https://accounts.tsu.ru/api/profile"); 
        httpClient.DefaultRequestHeaders.Add("Authorization", "Basic YWNjb3VudHM6RXdjemN2MEE/cTkjbzZI");
        _accountClient = RestService.For<IAccountClient>(httpClient);
    }

    public async Task<AccountProfile> GetProfile(Guid id)
    {
        var res = await _accountClient.GetProfileById(id);

        return res;
    }

    public async Task<List<UserShortModel>> GetProfile(string namePart)
    {
        var res = await _accountClient.GetProfileByNamePart(namePart);

        return res;
    }
}
