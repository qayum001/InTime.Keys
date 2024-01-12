using InTime.Keys.Application.DTOs.BidDTOs;
using InTime.Keys.Application.Interfaces.Repositories;
using InTime.Keys.Application.Interfaces.Repositories.BidRepositories;
using InTime.Keys.Domain.Enities;
using InTime.Keys.Domain.Enumerations;
using MediatR;
using System.Security.Cryptography;

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
    private readonly IUnitOfWork _unitOfWork;

    public GetActiveBidsQueryHandler(IBidListGetRepositiry bidRepository, IUnitOfWork unitOfWork)
    {
        _bidRepository = bidRepository;
        _unitOfWork = unitOfWork;
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
