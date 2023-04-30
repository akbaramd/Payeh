using Microsoft.Extensions.DependencyInjection;
using Payeh.Contracts;
using Payeh.Messaging.Contracts;

namespace Payeh.Messaging.Configurators;

public class MessagingConfigurator : IMessagingConfigurator
{
    public MessagingConfigurator(IPayehBuilder builder)
    {
        Builder = builder;
    }

    public IPayehBuilder Builder { get; set; }
}