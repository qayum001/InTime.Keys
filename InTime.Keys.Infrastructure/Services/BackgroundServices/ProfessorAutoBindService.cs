using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace InTime.Keys.Infrastructure.Services.BackgroundServices;

public class ProfessorAutoBindService : BackgroundService
{
    private readonly IConfiguration _configuration;
    private Timer _timer;
    

    public ProfessorAutoBindService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(BidKeys, null, (long)GetStartTime().Milliseconds, TimeSpan.TicksPerDay);
        return base.StartAsync(cancellationToken);
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        _timer.Dispose();
        return base.StopAsync(cancellationToken);
    }

    private TimeSpan GetStartTime()
    {
        var startHour = int.Parse(_configuration["00 -> 23"]);
        var startMinute = int.Parse(_configuration["00 -> 59"]);

        var now = DateTime.UtcNow;
        var targetTime = new DateTime(now.Year, now.Month, now.Day + 1, startHour, startMinute, 0);
        var delay = targetTime - now;

        return delay;
    }

    private static void BidKeys(object? state)
    {
        //тут будет основная логика
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            
        }

        return Task.CompletedTask;
    }
}
