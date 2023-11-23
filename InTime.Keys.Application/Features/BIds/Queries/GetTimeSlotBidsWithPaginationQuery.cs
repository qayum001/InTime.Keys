using InTime.Keys.Application.DTOs.BidDTOs;
using InTime.Keys.Application.Interfaces.Repositories;
using InTime.Keys.Application.Interfaces.Repositories.BidRepositories;
using InTime.Keys.Domain.Enities;
using MediatR;

namespace InTime.Keys.Application.Features.BIds.Queries;

public class GetTimeSlotBidsWithPaginationQuery : IRequest<List<BidDto>>
{
    public DateTime Date { get; }
    public int TimeSlot { get; }
    public int Page { get; }
    public int Size { get; }

    public GetTimeSlotBidsWithPaginationQuery(DateTime date, int timeSlot, int page, int size)
    {
        Date = date;
        TimeSlot = timeSlot;
        Page = page;
        Size = size;
    }
}

public class GetTimeSlotBidsWithPaginationQueryHandler : IRequestHandler<GetTimeSlotBidsWithPaginationQuery, List<BidDto>>
{
    private readonly IBidListGetRepositiry _bidRepository;

    public GetTimeSlotBidsWithPaginationQueryHandler(IBidListGetRepositiry bidListGetRepositiry)
    {
        _bidRepository = bidListGetRepositiry;
    }

    public async Task<List<BidDto>> Handle(GetTimeSlotBidsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var bids = await _bidRepository.GetBidsWithPropertiesByPagination(request.Date, request.Page, request.Size);

        var res = new List<BidDto>();

        foreach (var bid in bids)
        {
            if (bid.TimeSlot.LessonNumber != request.TimeSlot)
                continue;

            var dto = new BidDto(bid.Id, bid.TimeSlot.Date, bid.TimeSlot.LessonNumber, 
                bid.Key.Id, bid.Key.AudienceId, bid.Key.AudienceName, bid.BidStatus);

            res.Add(dto);
        }

        return res;
    }
}
