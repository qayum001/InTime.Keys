using InTime.Keys.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InTime.Keys.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CreateKeysController : ControllerBase
{
    private readonly IKeysCreateService _keysCreateService;

    public CreateKeysController(IKeysCreateService keysCreateService)
    {
        _keysCreateService = keysCreateService;
    }
    [HttpPost]
    public async Task<ActionResult> CreateKeys()
    {
        await _keysCreateService.CreateKeys();
        return Ok();
    }
}
