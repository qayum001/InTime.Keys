using InTime.Keys.Application.Interfaces.Repositories;
using InTime.Keys.Domain.Enities;
using MediatR;

namespace InTime.Keys.Application.Features.Users.Commands;

public record CreateUserCommand : IRequest
{
    public string FullName { get; set;}
    public Guid UserId { get; set;}

    public CreateUserCommand(string FullName, Guid UserId)
    {
        this.FullName = FullName;
        this.UserId = UserId;
    }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork) 
    {
        _unitOfWork = unitOfWork; 
    }
    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var newUser = User.Create(request.FullName, request.UserId);

        await _unitOfWork.Repository<User>().AddAsync(newUser);

        await _unitOfWork.Save(cancellationToken);
    }
}
