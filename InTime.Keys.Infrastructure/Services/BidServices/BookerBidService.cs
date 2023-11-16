using InTime.Keys.Application.DTOs.BidDTOs;
using InTime.Keys.Application.Features.BIds.Commands;
using InTime.Keys.Application.Features.BIds.Queries;
using InTime.Keys.Application.Interfaces.Services.BidServices;
using MediatR;

namespace InTime.Keys.Infrastructure.Services.BidServices;

public class BookerBidService : IBookerBidService
{
    private readonly IMediator _mediator;

    public BookerBidService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task CloseBid(Guid closerId, Guid bidId)
    {
        var command = new CloseBidCommand(closerId, bidId);
        await _mediator.Send(command);
    }

    public async Task CreateBid(Guid KeyId, DateTime date, int timeSlot, Guid userId)
    {
        var command = new CreateBidCommand(userId, KeyId, timeSlot, date);
        await _mediator.Send(command);
    }

    public async Task<List<BidDto>> GetUserBidList(Guid userId)
    {
        //TODO: тут должна быть  какая-то проверка что пользователь существует
        // и проверка на то что в расписании слот запроса свободный        

        var query = new GetUserBidsListQuery(userId);
        return await _mediator.Send(query);
    }
}