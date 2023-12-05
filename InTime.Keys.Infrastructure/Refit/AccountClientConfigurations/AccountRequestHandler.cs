
namespace InTime.Keys.Infrastructure.Refit.AccountClientConfigurations;


//можно удалять
public class AccountRequestHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Request: {request.Method} {request.Headers.Where(e => e.Key == "Authorization")}");

        request.Headers.Add("Authorization", "Basic YWNjb3VudHM6RXdjemN2MEE/cTkjbzZI");

        return await base.SendAsync(request, cancellationToken).ConfigureAwait(false); ;
    }
}