using InTime.Keys.Domain.Enities;
using InTime.Keys.Domain.Enumerations;

namespace InTime.Keys.Application.Interfaces.Repositories.BidRepositories;

public interface IBidListGetRepositiry
{
    public Task<IEnumerable<Bid>> GetBidsWithIncludedPropertiesByBookerId(Guid bookerId);
    public Task<IEnumerable<Bid>> GetBidsWithIncludedPropertiesByStatus(BidStatus status);
    public Task<IEnumerable<Bid>> GetBidsWithIncludedPropertiesByIvertedStatus(BidStatus status);

}
