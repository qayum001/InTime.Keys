using InTime.Keys.Application.DTOs.BidDTOs;
using InTime.Keys.Application.Features.BIds.Commands;
using InTime.Keys.Application.Features.BIds.Queries;
using InTime.Keys.Application.Features.Users.Commands;
using InTime.Keys.Application.Features.Users.Queries;
using InTime.Keys.Application.Interfaces.Services.BidServices;
using InTime.Keys.Infrastructure.Refit.AccountClientConfigurations;
using InTime.Keys.Infrastructure.Services.UserServices.UserSeachService;
using MediatR;

namespace InTime.Keys.Infrastructure.Services.BidServices;

public class BookerBidService : IBookerBidService
{
    private readonly IMediator _mediator;
    private readonly IUserSearchService _userSearchService;

    public BookerBidService(IMediator mediator, IUserSearchService SearchService)
    {
        _mediator = mediator;
        _userSearchService = SearchService;
    }

    public async Task CloseBid(Guid closerId, Guid bidId)
    {
        var command = new CloseBidCommand(closerId, bidId);
        await _mediator.Send(command);
    }

    public async Task CreateBid(Guid KeyId, DateTime date, int timeSlot, Guid userId)
    {
        var user = await _mediator.Send(new CheckUserExistenseCommand(userId));
        if (user)
        {
            var profile = await _userSearchService.GetUserById(userId);

            await _mediator.Send(new CreateUserCommand(profile.FullName, userId));
        }

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