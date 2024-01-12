using InTime.Keys.Application.DTOs.BidDTOs;
using InTime.Keys.Application.Interfaces.Repositories;
using InTime.Keys.Application.Interfaces.Repositories.BidRepositories;
using InTime.Keys.Domain.Enities;
using MediatR;
using System.Reflection.Metadata;

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
    private readonly IUnitOfWork _unitOfWork;

    public GetTimeSlotBidsWithPaginationQueryHandler(IBidListGetRepositiry bidListGetRepositiry, IUnitOfWork unitOfWork)
    {
        _bidRepository = bidListGetRepositiry;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<BidDto>> Handle(GetTimeSlotBidsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var bids = await _bidRepository.GetBidsWithPropertiesByPagination(request.Date, request.Page, request.Size);

        var res = new List<BidDto>();

        foreach (var b in bids)
        {
            if (b.TimeSlot.LessonNumber != request.TimeSlot)
                continue;

            var currentUser = _unitOfWork.Repository<User>().Entities.FirstOrDefault(e => e.UserId == b.UserId);

            if (currentUser is null)
            {
                var nullDto = new BidDto(b.Id, b.TimeSlot.Date, b.TimeSlot.LessonNumber, 
                    b.Key.Id, b.Key.AudienceId, b.Key.AudienceName, b.BidStatus, null, null);
                res.Add(nullDto);
                continue;
            }
            var dto = new BidDto(b.Id, b.TimeSlot.Date, b.TimeSlot.LessonNumber,
                b.Key.Id, b.Key.AudienceId, b.Key.AudienceName, b.BidStatus, null, null);

            res.Add(dto);
        }

        return res;
    }
}
