using InTime.Keys.Infrastructure.Refit.AccountModels;
using InTime.Keys.Infrastructure.Services.UserServices.UserSeachService;
using Microsoft.AspNetCore.Mvc;

namespace InTime.Keys.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserSearchService _userSearchService;

    public UserController(IUserSearchService userSearchService)
    {
        _userSearchService = userSearchService;
    }

    [HttpGet("{id}/user")]
    public async Task<ActionResult<AccountProfile>> GetUserById(Guid id)
    {
        try
        {
            var res = await _userSearchService.GetUserById(id);

            return Ok(res);
        }catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{namePart}/users")]
    public async Task<ActionResult<List<UserShortModel>>> GetUserByNamePart(string namePart)
    {
        try
        {
            var res = await _userSearchService.GetUserListByNamePart(namePart);

            return Ok(res);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
