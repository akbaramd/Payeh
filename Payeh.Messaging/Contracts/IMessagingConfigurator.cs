using Microsoft.Extensions.DependencyInjection;
using Payeh.Contracts;

namespace Payeh.Messaging.Contracts;

public interface IMessagingConfigurator
{
    public IPayehBuilder Builder { get; set; }
}