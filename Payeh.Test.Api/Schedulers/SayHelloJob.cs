using Payeh.Scheduler.BackgroundServices;

namespace Payeh.Test.Api.Schedulers;

public class SayHelloJob : ImmediatelyJob
{
    public SayHelloJob() : base(1000)
    {
    }

    protected override Task HandleAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Say Hello For Every One");
        return Task.CompletedTask;
    }
}