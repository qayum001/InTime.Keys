using InTime.Keys.Application.DTOs.BidDTOs;
using InTime.Keys.Application.DTOs.UserDTOs;

namespace InTime.Keys.Application.Interfaces.Services.BidServices;

public interface IBidService
{
    Task<List<BidDto>> GetUserBidList(Guid userId);
    Task CreateBid(Guid KeyId, DateTime date, int timeSlot, Guid userId);
    Task CloseBid(Guid closerId, Guid bidId);
}