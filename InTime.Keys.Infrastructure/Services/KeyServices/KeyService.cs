using InTime.Keys.Application.DTOs.KeyDTOs;
using InTime.Keys.Application.Features.Keys.Queries;
using InTime.Keys.Application.Interfaces.Services.KeyServices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTime.Keys.Infrastructure.Services.KeyServices;

public class KeyService : IKeyService
{
    private readonly IMediator _mediator;

    public KeyService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<List<KeyDto>> GetAllKeys()
    {
        var res = await _mediator.Send(new GetAllKeysQuery());

        return res;
    }
}
