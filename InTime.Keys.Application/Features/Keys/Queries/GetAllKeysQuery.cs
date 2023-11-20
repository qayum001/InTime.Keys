using InTime.Keys.Application.DTOs.KeyDTOs;
using InTime.Keys.Application.Interfaces.Repositories;
using InTime.Keys.Domain.Enities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace InTime.Keys.Application.Features.Keys.Queries;

public class GetAllKeysQuery : IRequest<List<KeyDto>>
{
}

public class GetAllKeysQueryHandler : IRequestHandler<GetAllKeysQuery, List<KeyDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllKeysQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<KeyDto>> Handle(GetAllKeysQuery request, CancellationToken cancellationToken)
    {
        var keys = await _unitOfWork.Repository<Key>().GetAll();

        var res = new List<KeyDto>();

        foreach (var key in keys)
        {
            res.Add(new KeyDto(key.Id, key.AudienceId, key.AudienceName, key.Status));
        }

        return res;
    }
}
