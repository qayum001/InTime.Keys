using InTime.Keys.Application.DTOs.Building;
using InTime.Keys.Application.Features.Keys.Commands;
using InTime.Keys.Application.Services;
using InTime.Keys.Infrastructure.Refit.Interfaces;
using MediatR;

namespace InTime.Keys.Infrastructure.Services;

public class KeysCreateService : IKeysCreateService
{
    private readonly IMediator _mediator;
    private readonly IInTimeClient _client;

    public KeysCreateService(IMediator mediator, IInTimeClient client)
    {
        _mediator = mediator;
        _client = client;
    }

    public async Task CreateKeys()
    {
        var audiences = await _client.GetAudiencesAsync(new Guid("4761a634-bffd-11ea-8117-005056bc52bb"))
            ?? throw new NullReferenceException($"can not create client");
        var dtoList = new List<AudienceDto>();

        foreach (var audience in audiences)
            dtoList.Add(new AudienceDto(audience.Id, audience.Name));

         await _mediator.Send(new CreateBuildingKeysCommand(dtoList));
    }
}
