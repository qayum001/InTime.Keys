using System.Net.Mail;

namespace InTime.Keys.Infrastructure.Services.EmailServices;

public interface ISmtpClientFabric
{
    Task<SmtpClient> GetBaseSmtpClient();
}
