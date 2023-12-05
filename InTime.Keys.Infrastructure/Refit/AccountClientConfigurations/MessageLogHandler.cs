using System.Net.Http.Headers;

namespace InTime.Keys.Infrastructure.Refit.AccountClientConfigurations;

public class MessageLogHandler : HttpClientHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    { 
        Console.WriteLine($"Request URI: {request.RequestUri}");
        Console.WriteLine("Headers:");
        foreach (var header in request.Headers)
        {
            Console.WriteLine($"{header.Key}: {string.Join(", ", header.Value)}");
        }

        var response = await base.SendAsync(request, cancellationToken);
  
        Console.WriteLine($"Response Status Code: {response.StatusCode}");
        Console.WriteLine("Response Headers:");
        foreach (var header in response.Headers)
        {
            Console.WriteLine($"{header.Key}: {string.Join(", ", header.Value)}");
        }

        return response;
    }
}