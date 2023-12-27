using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace InTime.Keys.Infrastructure.Services.EmailServices;

public class SmtpClientFabric : ISmtpClientFabric
{
    private readonly IConfiguration _configuration;

    public SmtpClientFabric(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Task<SmtpClient> GetBaseSmtpClient()
    {
        var smtpServer = _configuration.GetSection("EmailSettings:SmtpServer").Value;
        var port = _configuration.GetSection("EmailSettings:Port").Value;
        var username = _configuration.GetSection("EmailSettings:Username").Value;
        var password = _configuration.GetSection("EmailSettings:Password").Value;

        SmtpClient smtpClient = new(smtpServer, int.Parse(port))
        {
            Credentials = new NetworkCredential(username, password),
            EnableSsl = true, // использовать SSL
        };

        return Task.FromResult(smtpClient);
    }
}
