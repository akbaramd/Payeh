using Payeh.Messaging.Contracts;

namespace Payeh.Messaging.RabbitMQ;

public static class Extensions
{
    public static IMessagingConfigurator AddMessaging(this IMessagingConfigurator configure)
    {
        return configure;
    }
}