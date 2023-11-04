using InTime.Keys.Application.DTOs.Building;
using InTime.Keys.Application.Interfaces.Repositories;
using InTime.Keys.Domain.Enities;
using MediatR;

namespace InTime.Keys.Application.Features.Keys.Commands;

public record CreateBuildingKeysCommand : IRequest
{
    public List<AudienceDto> Audiences { get; set; } = new List<AudienceDto>();

    public CreateBuildingKeysCommand(List<AudienceDto> audiences)
    { 
        Audiences = audiences;
    }
}

public class CreateBuildingKeysCommandHadler : IRequestHandler<CreateBuildingKeysCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateBuildingKeysCommandHadler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateBuildingKeysCommand request, CancellationToken cancellationToken)
    {
        foreach(var audience in request.Audiences)
        {
            var key = Key.Create(audience.Id, audience.Name);
            await _unitOfWork.Repository<Key>().AddAsync(key);
            await _unitOfWork.Save(cancellationToken);
        }
    }
}