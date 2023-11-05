using InTime.Keys.Application.Interfaces.Repositories.BidRepositories;
using InTime.Keys.Domain.Enities;
using Microsoft.EntityFrameworkCore;

namespace InTime.Keys.Persistence.Contexts.EfCore.Repositories.BidRepositories;

public class UserBidListGetRepositiry : IUserBidListGetRepositiry
{
    private readonly ApplicationDbContext _context;

    public UserBidListGetRepositiry(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Bid>> GetBidsWithIncludedPropertiesByBookerId(Guid bookerId)
    {
        return await _context.Bids.
            Include(e => e.Key).
            Include(e => e.TimeSlot).
            Where(e => e.UserId == bookerId).
            ToListAsync();
    }
}
