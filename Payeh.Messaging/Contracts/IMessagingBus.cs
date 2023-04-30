namespace Payeh.Messaging.Contracts;

public interface IMessagingBus
{
    Task PublishAsync<TMessage>(TMessage message,CancellationToken cancellationToken = default);
    Task SendAsync<TMessage>(string serviceId,TMessage message,CancellationToken cancellationToken = default);
}