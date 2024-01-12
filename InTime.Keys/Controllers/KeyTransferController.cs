using InTime.Keys.Application.DTOs.KeyTransferDTOs;
using InTime.Keys.Application.Interfaces.Services.BidServices;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace InTime.Keys.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KeyTransferController : ControllerBase
{
    private readonly IKeyTransferService _keyTransferService;

    public KeyTransferController(IKeyTransferService keyTransferService)
    {
        _keyTransferService = keyTransferService;
    }

    [HttpPost("createTransfer")]
    public async Task<ActionResult> CreateKeyTransfer(Guid senderId, Guid receiverId, Guid KeyId, int timeSlot, DateTime date)
    {
        //try
        //{
            await _keyTransferService.TransferKey(senderId, receiverId, KeyId, timeSlot, date);

            return Ok();
        //}
        //catch (Exception ex)
        //{
        //    return BadRequest(ex.Message);
        //}
    }

    [HttpPut("{value}/approveTransfer")]
    public async Task<ActionResult> ApproveTransfer(string value)
    {
        throw new NotImplementedException();
    }

    [HttpGet("getUserTransfer")]
    public async Task<ActionResult<List<KeyTransferDto>>> GetUserKeyTransfers(Guid id)
    {
        try
        {
            var res = await _keyTransferService.GetUserTransfers(id);
            return Ok(res);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}