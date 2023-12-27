using InTime.Keys.Domain.Enities;
using InTime.Keys.Infrastructure.Services.UserServices.UserSeachService;
using NETCore.MailKit.Core;
using NETCore.MailKit.Infrastructure.Internal;
using System.Net.Mail;
using System.Text;

namespace InTime.Keys.Infrastructure.Services.EmailServices;

public class KeyTransferEmailService : IKeyTransferEmailService
{
    private readonly ISmtpClientFabric _clientFabric;
    private readonly IUserSearchService _userSearch;
    public KeyTransferEmailService(ISmtpClientFabric clientFabric, IUserSearchService userSearch)
    {
        _clientFabric = clientFabric;
        _userSearch = userSearch;
    }

    public async Task SendTrnansfer(KeyTransfer keyTransfer)
    {
        using var client = await _clientFabric.GetBaseSmtpClient();

        var receiver = await _userSearch.GetUserById(keyTransfer.ReceiverId);

        var receiverEmail = receiver.Email;

        var approveUri = $"https://localhost:44389/api/KeyTransfer/{keyTransfer.TransferHash}/approveTransfer";

        var message = new MailMessage("qayumoka11@gmail.com", receiverEmail, "Подтверждение получения ключа", "перейдите по ссылке для подтверждение получения ключа \n " +
            $"{approveUri}");
    }
}