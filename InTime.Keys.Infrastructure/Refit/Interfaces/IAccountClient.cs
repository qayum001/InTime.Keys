using InTime.Keys.Infrastructure.Refit.AccountModels;
using Refit;

namespace InTime.Keys.Infrastructure.Refit.Interfaces;

public interface IAccountClient
{
    [Get("/GetUserModel?id={accountId}")]
    Task<AccountProfile> GetProfileById(Guid accountId);

    [Get("/GetShortModelList?namePart={namePart}")]
    Task<List<UserShortModel>> GetProfileByNamePart(string namePart);

    [Get("/GetActualUsers?page=10&pagesize=100")]
    Task<PageInfo> GetProfileByNamePart(int page, int pageSize);
}
