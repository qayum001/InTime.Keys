using InTime.Keys.Application.DTOs.BidDTOs;

namespace InTime.Keys.Application.Interfaces.Services.BidServices;

public interface IBidControlService
{
    public Task<List<BidDto>> GetPendingBids();
    public Task<List<BidDto>> GetActiveBids();//approved bids which is now in use or just booked
    public Task DenayBid(Guid bidId, string message = "");
    public Task ApproveBid(Guid bidId);
}
