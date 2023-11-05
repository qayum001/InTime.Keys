using InTime.Keys.Domain.Enities;

namespace InTime.Keys.Application.Interfaces.Repositories.BidRepositories;

public interface IUserBidListGetRepositiry
{
    public Task<List<Bid>> GetBidsWithIncludedPropertiesByBookerId(Guid bookerId);
}
