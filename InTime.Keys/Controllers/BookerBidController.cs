using InTime.Keys.Application.DTOs.BidDTOs;
using InTime.Keys.Application.Interfaces.Services.BidServices;
using Microsoft.AspNetCore.Mvc;

namespace InTime.Keys.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BookerBidController : ControllerBase
{
    private readonly IBidService _bidService;

    public BookerBidController(IBidService bidService)
    {
        _bidService = bidService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateBid(Guid userId, Guid keyId, DateTime date, int lessonNumber)
    {
        try
        {
            await _bidService.CreateBid(keyId, date, lessonNumber, userId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpPut]
    public async Task<ActionResult> CloseBid(Guid userId, Guid bidId)
    {
        try
        {
            await _bidService.CloseBid(userId, bidId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<BidDto>>> GetUserBids(Guid userId)
    {
        try
        {
            var bids = await _bidService.GetUserBidList(userId);
            return Ok(bids);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}