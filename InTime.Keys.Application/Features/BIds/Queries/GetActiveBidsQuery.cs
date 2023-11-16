using InTime.Keys.Application.DTOs.BidDTOs;
using InTime.Keys.Application.Interfaces.Repositories.BidRepositories;
using InTime.Keys.Domain.Enumerations;
using MediatR;

namespace InTime.Keys.Application.Features.BIds.Queries;

public record GetActiveBidsQuery : IRequest<List<BidDto>>
{ 
    public DateTime? Date { get; }
    public GetActiveBidsQuery(DateTime? date)
    {
        Date = date;
    }
}

public class GetActiveBidsQueryHandler : IRequestHandler<GetActiveBidsQuery, List<BidDto>>
{
    private readonly IBidListGetRepositiry _bidRepository;

    public GetActiveBidsQueryHandler(IBidListGetRepositiry bidRepository)
    {
        _bidRepository = bidRepository;
    }

    public async Task<List<BidDto>> Handle(GetActiveBidsQuery request, CancellationToken cancellationToken)
    {
        var bids = await _bidRepository.GetBidsWithIncludedPropertiesByIvertedStatus(BidStatus.Closed);

        if (request.Date != null)
        {
            bids = bids.Where(e => e.TimeSlot.Date == request.Date);
        }

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
