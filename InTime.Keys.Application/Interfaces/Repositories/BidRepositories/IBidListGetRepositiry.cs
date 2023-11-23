using InTime.Keys.Domain.Enities;
using InTime.Keys.Domain.Enumerations;
using MediatR;

namespace InTime.Keys.Application.Interfaces.Repositories.BidRepositories;

public interface IBidListGetRepositiry
{
    public Task<IEnumerable<Bid>> GetBidsWithPropertiesByPagination(DateTime Date, int page, int size);
    public Task<IEnumerable<Bid>> GetBidsWithIncludedPropertiesByBookerId(Guid bookerId);
    public Task<IEnumerable<Bid>> GetBidsWithIncludedPropertiesByStatus(BidStatus status);
    public Task<IEnumerable<Bid>> GetBidsWithIncludedPropertiesByIvertedStatus(BidStatus status);

}
