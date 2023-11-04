using InTime.Keys.Application.DTOs.BidDTOs;
using InTime.Keys.Application.Features.BIds.Commands;
using InTime.Keys.Application.Interfaces.Services.BidServices;
using MediatR;

namespace InTime.Keys.Infrastructure.Services.BidServices;

public class BidService : IBidService
{
    private readonly IMediator _mediator;

    public BidService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task CancelBid(Guid bidId)
    {
        throw new NotImplementedException();
    }

    public async Task CreateBid(Guid KeyId, DateTime date, int timeSlot, Guid userId)
    {
        var command = new CreateBidCommand(userId, KeyId, timeSlot, date);
        await _mediator.Send(command);
    }

    public List<BidDto> GetUserBidList(Guid userId)
    {
        throw new NotImplementedException();
    }
}