using InTime.Keys.Application.Interfaces.Repositories;
using InTime.Keys.Domain.Enities;
using MediatR;

namespace InTime.Keys.Application.Features.BIds.Commands;

public record ApproveBidCommand : IRequest
{
    public Guid BidId { get; }
    public ApproveBidCommand(Guid bidId)
    { 
        BidId = bidId;
    }
}

public class ApproveBidCommandHandler : IRequestHandler<ApproveBidCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public ApproveBidCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(ApproveBidCommand request, CancellationToken cancellationToken)
    {
        var bid = await _unitOfWork.Repository<Bid>().GetById(request.BidId);

        bid.Approve();

        await _unitOfWork.Save(cancellationToken);
    }
}
