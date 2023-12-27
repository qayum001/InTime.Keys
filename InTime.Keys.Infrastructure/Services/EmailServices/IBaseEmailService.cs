namespace InTime.Keys.Infrastructure.Services.EmailServices;

public interface IBaseEmailService
{
    Task Send(string email, string title, string message);
}
