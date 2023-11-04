using InTime.Keys.Application.DTOs.BidDTOs;
using InTime.Keys.Application.DTOs.UserDTOs;

namespace InTime.Keys.Application.Interfaces.Services.BidServices;

public interface IBidService
{
    List<BidDto> GetUserBidList(Guid userId);
    Task CreateBid(Guid KeyId, DateTime date, int timeSlot, Guid userId);
    Task CancelBid(Guid bidId);
}