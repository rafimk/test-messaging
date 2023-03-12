using Messaging.Shared.Abstractions;

namespace Messaginh.Shared.RabbitMQ.Internals;

public interface IMessageHandler
{
    Task HandleAsync<T>(Func<IServiceProvider, T, CancellationToken, Task> handler, T message,
        CancellationToken cancellationToken = default) where T : IMessage;
}