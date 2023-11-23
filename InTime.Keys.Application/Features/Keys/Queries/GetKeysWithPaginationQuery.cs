using InTime.Keys.Application.DTOs.KeyDTOs;
using InTime.Keys.Application.Interfaces.Repositories;
using InTime.Keys.Domain.Enities;
using MediatR;

namespace InTime.Keys.Application.Features.Keys.Queries;

public record GetKeysWithPaginationQuery(int Index, int Size) : IRequest<List<KeyDto>> { }

public class GetKeysWithPaginationQueryHandler : IRequestHandler<GetKeysWithPaginationQuery, List<KeyDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetKeysWithPaginationQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<KeyDto>> Handle(GetKeysWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var keys = await _unitOfWork.Repository<Key>().GetAll();   
        //сделать адекватное получения ключей

        var selected = keys.Skip((request.Index - 1) * request.Size).Take(request.Size);
        var dtoList = new List<KeyDto>();

        foreach (var key in selected) 
        {
            dtoList.Add(new KeyDto(key.Id, key.AudienceId, key.AudienceName, key.Status));
        }

        return dtoList;
    }
} 
