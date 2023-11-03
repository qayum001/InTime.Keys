using InTime.Keys.Application.DTOs.UserDTOs;
using MediatR;

namespace InTime.Keys.Application.Features.BIds.Commands;

public record CreateBidCommand : IRequest
{
    public UserDto User { get; private set; }
}

public class CreaterBidCommandHandler : IRequestHandler<CreateBidCommand>
{
    public Task Handle(CreateBidCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
