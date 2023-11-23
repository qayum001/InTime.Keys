using InTime.Keys.Application.Interfaces.Repositories.BidRepositories;
using InTime.Keys.Domain.Enities;
using InTime.Keys.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;

namespace InTime.Keys.Persistence.Contexts.EfCore.Repositories.BidRepositories;

public class BidListGetRepositiry : IBidListGetRepositiry
{
    private readonly ApplicationDbContext _context;

    public BidListGetRepositiry(ApplicationDbContext context)
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

    public async Task<IEnumerable<Bid>> GetBidsWithPropertiesByPagination(DateTime date, int page, int size)
    {
        return await _context.Bids.
            Include(e => e.Key).
            Include(e => e.TimeSlot).
            Where(e => e.TimeSlot.Date == date).
            Skip((page - 1) * size).
            Take(size).
            ToListAsync();
    }
}