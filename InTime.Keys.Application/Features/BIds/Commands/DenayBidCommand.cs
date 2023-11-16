using InTime.Keys.Application.Interfaces.Repositories;
using InTime.Keys.Domain.Enities;
using MediatR;

namespace InTime.Keys.Application.Features.BIds.Commands;

public record DenayBidCommand : IRequest
{
    public Guid BidId { get; }
    public string? Message { get; }

    public DenayBidCommand(Guid bidId, string message = "")
    {
        BidId = bidId;
        Message = message;
    }
}

public class DenayBidCommandHandler : IRequestHandler<DenayBidCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DenayBidCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DenayBidCommand request, CancellationToken cancellationToken)
    {
        var bid = await _unitOfWork.Repository<Bid>().GetById(request.BidId);

        bid.DenayBid(request.Message);

        await _unitOfWork.Save(cancellationToken);
    }
}