using Microsoft.Extensions.Hosting;

namespace Payeh.Scheduler.BackgroundServices;

public abstract class ImmediatelyJob : BackgroundService
{
    private readonly int _delayMilliseconds = 1;
    
    protected ImmediatelyJob(TimeSpan span)
    {
        _delayMilliseconds = span.Milliseconds;
    }
    
    protected ImmediatelyJob(int milliseconds)
    {
        _delayMilliseconds = milliseconds;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (true)
        {
            if (stoppingToken.IsCancellationRequested) break;

            await HandleAsync(stoppingToken);
            
            await Task.Delay(_delayMilliseconds, stoppingToken);
        }
    }


    protected abstract Task HandleAsync(CancellationToken stoppingToken);
}