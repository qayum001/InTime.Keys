using InTime.Keys.Application.DTOs.BidDTOs;
using InTime.Keys.Application.Interfaces.Repositories;
using InTime.Keys.Application.Interfaces.Repositories.BidRepositories;
using InTime.Keys.Domain.Enities;
using MediatR;

namespace InTime.Keys.Application.Features.BIds.Queries;

public record GetUserBidsListQuery : IRequest<List<BidDto>>
{
    public Guid UserId { get; }

    public GetUserBidsListQuery(Guid userId)
    {
        UserId = userId;
    }
}

public class GetUserBidListQueryHandler : IRequestHandler<GetUserBidsListQuery, List<BidDto>>
{
    private readonly IUserBidListGetRepositiry _bidRepository;
    
    public GetUserBidListQueryHandler(IUserBidListGetRepositiry unitOfWork)
    {
        _bidRepository = unitOfWork;
    }
    public async Task<List<BidDto>> Handle(GetUserBidsListQuery request, CancellationToken cancellationToken)
    {
        var bids = await _bidRepository.GetBidsWithIncludedPropertiesByBookerId(request.UserId);

        var dtoList = new List<BidDto>();

        foreach (var b in bids)
        {
            var dto = new BidDto(b.Id, b.TimeSlot.Date, b.TimeSlot.LessonNumber,
                b.Key.Id, b.Key.AudienceId, b.Key.AudienceName, b.BidStatus);
            dtoList.Add(dto);
        }

        return dtoList;
    }
}
