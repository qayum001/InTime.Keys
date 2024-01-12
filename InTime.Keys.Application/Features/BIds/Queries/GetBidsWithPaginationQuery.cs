using InTime.Keys.Application.DTOs.BidDTOs;
using InTime.Keys.Application.Interfaces.Repositories;
using InTime.Keys.Application.Interfaces.Repositories.BidRepositories;
using InTime.Keys.Domain.Enities;
using InTime.Keys.Domain.Enumerations;
using MediatR;
using System.Security.Cryptography;

namespace InTime.Keys.Application.Features.BIds.Queries;

public record GetBidsWithPaginationQuery : IRequest<List<BidDto>>
{
    public DateTime? Date { get; }
    public BidStatus BidStatus { get; }

    public GetBidsWithPaginationQuery(DateTime? date, BidStatus bidStatus)
    {
        Date = date;
        BidStatus = bidStatus;
    }
}

public class GetBidsWithPaginationCommandHandler : IRequestHandler<GetBidsWithPaginationQuery, List<BidDto>>
{
    private readonly IBidListGetRepositiry _bidRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetBidsWithPaginationCommandHandler(IBidListGetRepositiry bidRepository, IUnitOfWork unitOfWork)
    {
        _bidRepository = bidRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<BidDto>> Handle(GetBidsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var bids = await _bidRepository.GetBidsWithIncludedPropertiesByStatus(request.BidStatus);

        if (request.Date != null)
        {
            bids = bids.Where(e => e.TimeSlot.Date == request.Date);
        }

        var dtoList = new List<BidDto>();

        foreach (var b in bids)
        {
            var currentUser = _unitOfWork.Repository<User>().Entities.FirstOrDefault(e => e.UserId == b.UserId);

            if (currentUser is null)
            {
                var nullDto = new BidDto(b.Id, b.TimeSlot.Date, b.TimeSlot.LessonNumber,
                b.Key.Id, b.Key.AudienceId, b.Key.AudienceName, b.BidStatus, null, null);
                dtoList.Add(nullDto);
                continue;
            }
            var dto = new BidDto(b.Id, b.TimeSlot.Date, b.TimeSlot.LessonNumber,
                b.Key.Id, b.Key.AudienceId, b.Key.AudienceName, b.BidStatus, currentUser.UserId, currentUser.FullName);
            dtoList.Add(dto);
        }

        return dtoList;
    }
}
