using InTime.Keys.Application.DTOs.KeyDTOs;
using InTime.Keys.Application.Interfaces.Services.KeyServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InTime.Keys.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyController : ControllerBase
    {
        private readonly IKeyService _keyService;

        public KeyController(IKeyService keyService)
        {
            _keyService = keyService;
        }

        [HttpGet]
        public async Task<ActionResult<List<KeyDto>>> GetAllKeys()
        {
            try
            {
                var res = await _keyService.GetAllKeys();

                return Ok(res);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
