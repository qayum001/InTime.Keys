using InTime.Keys.Application.DTOs.BidDTOs;
using InTime.Keys.Application.DTOs.UserDTOs;

namespace InTime.Keys.Application.Interfaces.Services.BidServices;

public interface IBidService
{
    List<BidDto> GetUserBidList(UserDto user);
    Task CreateBid();
    Task CancelBid();
}
