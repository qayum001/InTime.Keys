using InTime.Keys.Application.Interfaces.Repositories;
using InTime.Keys.Domain.Enities;
using MediatR;
using System.Diagnostics.Contracts;

namespace InTime.Keys.Application.Features.BIds.Commands;

public record CreateKeyTransferBidCommand : IRequest<KeyTransfer>
{
    public Guid SenderId { get; }
    public Guid ReceiverId { get; }
    public string TransferHash { get; }
    public Guid KeyId { get; }
    public int TimeSlot { get; }
    public DateTime Date { get; }

    public CreateKeyTransferBidCommand (Guid senderId, Guid receiverId, string transferHash, Guid keyId, int timeSlot, DateTime date)
    {
        SenderId = senderId;
        ReceiverId = receiverId;            
        TransferHash = transferHash;
        KeyId = keyId;
        TimeSlot = timeSlot;
        Date = date;
    }
}

public class CreateKeyTransferBidCommandHandler : IRequestHandler<CreateKeyTransferBidCommand, KeyTransfer>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateKeyTransferBidCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<KeyTransfer> Handle(CreateKeyTransferBidCommand request, CancellationToken cancellationToken)
    {
        var timeSlot = TimeSlot.Create(request.TimeSlot, request.Date);

        var kTransfer = KeyTransfer.Create(request.SenderId, request.ReceiverId, request.KeyId, request.TransferHash, timeSlot, DateTime.Now);
        
        await _unitOfWork.Repository<KeyTransfer>().AddAsync(kTransfer);
        await _unitOfWork.Save(cancellationToken);

        return kTransfer;
    }
}