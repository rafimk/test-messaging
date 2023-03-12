using Messaging.Shared.Abstractions;
using Messaging.Shared.Attributes;
using Messaging.Shared.Handlers;
using Messaging.Shared.Transactions.Outbox;

namespace Messaging.Shared.Transactions.Decorators;

[Decorator]
internal sealed class OutboxInstantSenderEventHandlerDecorator<T> : IEventHandler<T> where T : class, IEvent
{
    private readonly IEventHandler<T> _handler;
    private readonly IOutbox _outbox;

    public OutboxInstantSenderEventHandlerDecorator(IEventHandler<T> handler, IOutbox outbox)
    {
        _handler = handler;
        _outbox = outbox;
    }

    public async Task HandleAsync(T @event, CancellationToken cancellationToken = default)
    {
        await _handler.HandleAsync(@event, cancellationToken);
        await _outbox.PublishAwaitingAsync(cancellationToken);
    }
}