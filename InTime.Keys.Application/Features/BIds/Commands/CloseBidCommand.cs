using InTime.Keys.Application.Features.BIds.Commands;
using InTime.Keys.Application.Interfaces.Repositories;
using InTime.Keys.Domain.Enities;
using MediatR;

namespace InTime.Keys.Application.Features.BIds.Commands;

public record CloseBidCommand : IRequest
{
    public Guid BidId { get; set; }
    public Guid CloserId { get; set;}

    public CloseBidCommand(Guid bidId, Guid closerId)
    {
        BidId = bidId;
        CloserId = closerId;
    }
}

public class CloseBidCommandHandler : IRequestHandler<CloseBidCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CloseBidCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CloseBidCommand request, CancellationToken cancellationToken)
    {
        var bid = await _unitOfWork.Repository<Bid>().GetById(request.BidId);

        if (bid == null)
        {
            return;
            //TODO: реализовать систему исключений или ответов которые указывают на ошибки
        }

        if (bid.UserId != request.CloserId)
        {
            return;
        }

        bid.CloseBid();

        await _unitOfWork.Save(cancellationToken);
    }
}
