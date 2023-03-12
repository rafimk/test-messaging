using Messaging.Shared.Abstractions;

namespace Messaging.Shared.Handlers;

public interface IEventHandler<in TEvent> where TEvent : class, IEvent
{
    Task HandleAsync(TEvent @event, CancellationToken cancellationToken = default);
}