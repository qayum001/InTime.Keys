using InTime.Keys.Application.Interfaces.Repositories.BidRepositories;
using InTime.Keys.Domain.Enities;
using InTime.Keys.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;

namespace InTime.Keys.Persistence.Contexts.EfCore.Repositories.BidRepositories;

public class UserBidListGetRepositiry : IBidListGetRepositiry
{
    private readonly ApplicationDbContext _context;

    public UserBidListGetRepositiry(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Bid>> GetBidsWithIncludedPropertiesByStatus(BidStatus status)
    {
        return await _context.Bids.
            Include(e => e.Key).
            Include(e => e.TimeSlot).
            Where(e => e.BidStatus == status).
            ToListAsync();
    }

    public async Task<IEnumerable<Bid>> GetBidsWithIncludedPropertiesByBookerId(Guid bookerId)
    {
        return await _context.Bids.
            Include(e => e.Key).
            Include(e => e.TimeSlot).
            Where(e => e.UserId == bookerId).
            ToListAsync();
    }

    public async Task<IEnumerable<Bid>> GetBidsWithIncludedPropertiesByIvertedStatus(BidStatus status)
    {
        return await _context.Bids.
            Include(e => e.Key).
            Include(e => e.TimeSlot).
            Where(e => e.BidStatus != status && e.BidStatus != BidStatus.Closed && e.BidStatus != BidStatus.Denied).
            ToListAsync();
    }
}