using InTime.Keys.Application.Features.BIds.Commands;
using InTime.Keys.Application.Features.BIds.Queries;
using InTime.Keys.Application.Features.KeyTransfers.Queries;
using InTime.Keys.Application.Interfaces.Services.BidServices;
using InTime.Keys.Infrastructure.Services.EmailServices;
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
    private readonly IKeyTransferEmailService _keyTransferEmailService;

    public KeyTransferService(IMediator mediator, IConfiguration configuration, IKeyTransferEmailService keyTransferEmailService)
    {
        _mediator = mediator;
        _configuration = configuration;
        _keyTransferEmailService = keyTransferEmailService;
    }

    public Task ApporveTransfer(string hash)
    {
        throw new NotImplementedException();
    }

    /*    public Task ApporveTransfer(string hash)
        {
            var keyTransfer = _mediator.Send(new GetTransferByHashQuery(hash));
            if(keyTransfer != null)
            {
                throw new Exception("Transfer not found");
            }


        }
    */
    public async Task TransferKey(Guid senderId, Guid receiverId, Guid keyId, int timeSlot, DateTime date)
    {
        var senderBidList = await _mediator.Send(new GetUserBidsListQuery(senderId));

        if(!senderBidList.Any(e => e.KeyId == keyId && e.BidStatus == Domain.Enumerations.BidStatus.GiveAway))
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