
using InTime.Keys.Domain.Enities;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;

namespace InTime.Keys.Infrastructure.Services.EmailServices;

public class BaseEmailService : IBaseEmailService
{
    private readonly ISmtpClientFabric _clientFabric;
    private readonly IConfiguration _config;

    public BaseEmailService(ISmtpClientFabric clientFabric, IConfiguration configuration)
    {
        _clientFabric = clientFabric;
        _config = configuration;
    }

    public async Task Send(string email, string title, string message)
    {
        using var client = await _clientFabric.GetBaseSmtpClient();

        var senderEmail = _config.GetSection("EmailSettings:Username").Value;

        var mailMessage = new MailMessage(senderEmail, email, title, message);

        client.Send(mailMessage);
    }
}
