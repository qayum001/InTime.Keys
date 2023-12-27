using InTime.Keys.Application.Interfaces.Repositories;
using InTime.Keys.Domain.Enities;
using MediatR;

namespace InTime.Keys.Application.Features.KeyTransfers.Queries;

public record GetTransferByHashQuery : IRequest<KeyTransfer?>
{
    public string Hash { get; }

    public GetTransferByHashQuery(string hash)
    {
        Hash = hash;
    }
}

public class GetTransferByHashQueryHandler : IRequestHandler<GetTransferByHashQuery, KeyTransfer?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTransferByHashQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<KeyTransfer?> Handle(GetTransferByHashQuery request, CancellationToken cancellationToken)
    {
        var res = _unitOfWork.Repository<KeyTransfer>().Entities.
            FirstOrDefault(e => e.TransferHash == request.Hash);

        return Task.FromResult(res);
    }
}
