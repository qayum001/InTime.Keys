using InTime.Keys.Application.DTOs.KeyTransferDTOs;
using InTime.Keys.Application.Interfaces.Repositories;
using InTime.Keys.Domain.Enities;
using MediatR;

namespace InTime.Keys.Application.Features.KeyTransfers.Queries;

public record GetUserKeyTransfersQuery : IRequest<List<KeyTransferDto>>
{
    public Guid UserId { get; set; }

    public GetUserKeyTransfersQuery(Guid userId) 
    {
        UserId = userId;
    }
}

public class GetUserKeyTransfersQueryHandler : IRequestHandler<GetUserKeyTransfersQuery, List<KeyTransferDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUserKeyTransfersQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<List<KeyTransferDto>> Handle(GetUserKeyTransfersQuery request, CancellationToken cancellationToken)
    {
        var transfers = _unitOfWork.Repository<KeyTransfer>().Entities.Where(e => e.SenderId == request.UserId || e.ReceiverId == request.UserId);

        var res = new List<KeyTransferDto>();

        foreach (var item in transfers)
        {

            var dto = new KeyTransferDto(item.SenderId, item.ReceiverId);
            res.Add(dto);
        }

        return Task.FromResult(res);
    }
}
