using Messaging.Shared.Abstractions;

namespace Messaging.Shared.Handlers;

public interface IEventDispatcher
{
    Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : class, IEvent;
}