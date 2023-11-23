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
        private readonly IKeyGetService _keyService;

        public KeyController(IKeyGetService keyService)
        {
            _keyService = keyService;
        }

        [HttpGet("allKeys")]
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
        [HttpGet("byTimeslot")]
        public async Task<ActionResult<List<KeyDto>>> GetTimeSlotKeysWithStatus(DateTime date, int timeSlot, int page, int size)
        {
            try
            {
                var res = await _keyService.GetConcreteTimeSlotKeys(date, timeSlot, page, size);

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
