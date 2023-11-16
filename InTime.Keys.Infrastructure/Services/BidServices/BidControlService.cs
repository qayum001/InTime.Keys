using InTime.Keys.Application.DTOs.BidDTOs;
using InTime.Keys.Application.Features.BIds.Commands;
using InTime.Keys.Application.Features.BIds.Queries;
using InTime.Keys.Application.Interfaces.Services.BidServices;
using InTime.Keys.Domain.Enumerations;
using MediatR;
using System.Net.WebSockets;

namespace InTime.Keys.Infrastructure.Services.BidServices;

public class BidControlService : IBidControlService
{
    private readonly IMediator _mediator;

    public BidControlService(IMediator mediator)
    {
        _mediator = mediator;
    }

    //тут в методах должна быть проверка роли того кто изменяет статус заявки

    public async Task ApproveBid(Guid bidId)
    {
        var command = new ApproveBidCommand(bidId);
        await _mediator.Send(command);
    }

    public async Task DenayBid(Guid bidId, string message = "")
    {
        var command = new DenayBidCommand(bidId, message);
        await _mediator.Send(command);
    }

    public async Task<List<BidDto>> GetActiveBids()
    {
        var query = new GetActiveBidsQuery(null);
        return await _mediator.Send(query);
    }

    public async Task<List<BidDto>> GetPendingBids()
    {
        var query = new GetBidsWithPaginationQuery(null, BidStatus.Created);
        return await _mediator.Send(query);
    }
}
