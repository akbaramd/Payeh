using Microsoft.Extensions.DependencyInjection;
using Payeh.Contracts;
using Payeh.Messaging.Configurators;
using Payeh.Messaging.Contracts;

namespace Payeh.Messaging;

public static class Extensions
{
    public static IPayehBuilder AddMessaging(this IPayehBuilder builder,Action<IMessagingConfigurator> configure)
    {
        configure?.Invoke(new MessagingConfigurator(builder));
        
        return builder;
    }
    
    public static IPayehAppConfigure UseMessaging(this IPayehAppConfigure configure)
    {
        return configure;
    }
}