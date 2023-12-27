using InTime.Keys.Domain.Enities;

namespace InTime.Keys.Infrastructure.Services.EmailServices;

public interface IKeyTransferEmailService
{
    Task SendTrnansfer(KeyTransfer keyTransfer);
}
