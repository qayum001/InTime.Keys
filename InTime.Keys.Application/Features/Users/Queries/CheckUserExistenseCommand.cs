using InTime.Keys.Application.Interfaces.Repositories;
using InTime.Keys.Domain.Enities;
using MediatR;

namespace InTime.Keys.Application.Features.Users.Queries;

public record CheckUserExistenseCommand : IRequest<bool>
{
    public Guid UserId { get; set; }

    public CheckUserExistenseCommand(Guid userId)
    {
        UserId = userId;
    }
}

public class CheckUserExistenseCommandHandler : IRequestHandler<CheckUserExistenseCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public CheckUserExistenseCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(CheckUserExistenseCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Repository<User>().GetById(request.UserId);

        return user is null;
    }
}
