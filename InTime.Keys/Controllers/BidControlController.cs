using InTime.Keys.Application.DTOs.BidDTOs;
using InTime.Keys.Application.Interfaces.Services.BidServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace InTime.Keys.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidControlController : ControllerBase
    {
        private readonly IBidControlService _bidControlService;

        public BidControlController(IBidControlService bidControlService)
        {
            _bidControlService = bidControlService;
        }

        [HttpGet("active")]
        public async Task<ActionResult> GetActiveBids()
        {
            try
            {
                var res = await _bidControlService.GetActiveBids();
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("pending")]
        public async Task<ActionResult> GetPendingBids()
        {
            try
            {
                var res = await _bidControlService.GetPendingBids();
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut("deny")]
        public async Task<ActionResult> DenyBid(Guid id, string message)
        {
            try
            {
                await _bidControlService.DenayBid(id, message);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("approve")]
        public async Task<ActionResult> ApproveBid(Guid id)
        {
            try
            {
                await _bidControlService.ApproveBid(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
