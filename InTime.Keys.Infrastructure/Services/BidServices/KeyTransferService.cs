using InTime.Keys.Application.DTOs.KeyTransferDTOs;
using InTime.Keys.Application.Features.BIds.Commands;
using InTime.Keys.Application.Features.BIds.Queries;
using InTime.Keys.Application.Features.KeyTransfers.Queries;
using InTime.Keys.Application.Interfaces.Services.BidServices;
using InTime.Keys.Infrastructure.Services.EmailServices;
using InTime.Keys.Infrastructure.Services.UserServices.UserSeachService;
using MediatR;
using Microsoft.Extensions.Configuration;
using NETCore.MailKit.Core;
using System.Security.Cryptography;
using System.Text;

namespace InTime.Keys.Infrastructure.Services.BidServices;

public class KeyTransferService : IKeyTransferService
{
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;
    private readonly IUserSearchService _userSearchService;

    public KeyTransferService(IMediator mediator, IConfiguration configuration, IUserSearchService userSearchService)
    {
        _mediator = mediator;
        _configuration = configuration;
        _userSearchService = userSearchService;
    }

    public Task ApporveTransfer(string hash)
    {
        throw new NotImplementedException();
    }

    public async Task<List<KeyTransferDto>> GetUserTransfers(Guid userId)
    {
        var dtoList = await _mediator.Send(new GetUserKeyTransfersQuery(userId));

        foreach(var item in dtoList)
        {
            if (string.IsNullOrEmpty(item.SenderName))
            {
                var sender = await _userSearchService.GetUserById(item.SenderId);
                item.SenderName = sender.FullName;
            }
            if (string.IsNullOrEmpty(item.RecieverName))
            {
                var reciever = await _userSearchService.GetUserById(item.RecieverId);
                item.RecieverName = reciever.FullName;
            }
        }

        return dtoList;
    }

    public async Task TransferKey(Guid senderId, Guid receiverId, Guid keyId, int timeSlot, DateTime date)
    {
        var senderBidList = await _mediator.Send(new GetUserBidsListQuery(senderId));

        if(!senderBidList.Any(e => e.KeyId == keyId && e.BidStatus == Domain.Enumerations.BidStatus.Approved))
        {
            throw new Exception("Sender has no current key, please cancel bid or get key first");
        }

        var secret = Encoding.UTF8.GetBytes(_configuration.GetSection("KeyTransferSecret").Value);


        using var hmac = new HMACSHA256(secret);
        var signatureBytes = hmac.ComputeHash(keyId.ToByteArray());

        string signature = Convert.ToBase64String(signatureBytes);


        var keyTransfer = await _mediator.Send(new CreateKeyTransferBidCommand(senderId, receiverId, signature, keyId, timeSlot, date));

        //await _keyTransferEmailService.SendTrnansfer(keyTransfer);
    }
}