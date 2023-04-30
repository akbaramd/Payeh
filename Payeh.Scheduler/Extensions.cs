using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Payeh.Contracts;
using Payeh.Scheduler.BackgroundServices;

namespace Payeh.Scheduler;

public static class Extensions
{
    public static IPayehBuilder AddSchedulers(this IPayehBuilder builder)
    {
        var abstractType = typeof(ImmediatelyJob);
        var assembly = Assembly.GetExecutingAssembly();

        var immediatelyJobTypes = assembly.GetTypes().Where(x => abstractType.IsAssignableFrom(x) && !x.IsAbstract);

        foreach (var type in immediatelyJobTypes)
        {
            builder.Services.AddSingleton(typeof(IHostedService), type);
        }

        return builder;
    }
}