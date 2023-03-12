﻿using System.Collections.Concurrent;
using Humanizer;
using Messaging.Shared.Abstractions;
using Messaging.Shared.Attributes;
using Messaging.Shared.Contexts;
using Messaging.Shared.Handlers;

namespace Messaging.Shared.Transactions.Inbox;

[Decorator]
internal sealed class InboxEventHandlerDecorator<T> : IEventHandler<T> where T : class, IEvent
{
    private static readonly ConcurrentDictionary<Type, string> Names = new();
    private readonly IEventHandler<T> _handler;
    private readonly IContextProvider _contextProvider;
    private readonly IInbox _inbox;

    public InboxEventHandlerDecorator(IEventHandler<T> handler, IContextProvider contextProvider, IInbox inbox)
    {
        _handler = handler;
        _contextProvider = contextProvider;
        _inbox = inbox;
    }

    public Task HandleAsync(T @event, CancellationToken cancellationToken = default)
    {
        var context = _contextProvider.Current();
        var messageName = Names.GetOrAdd(typeof(T), typeof(T).Name.Underscore());
        if (_inbox.Enabled && !string.IsNullOrWhiteSpace(context.MessageId))
        {
            return _inbox.HandleAsync(context.MessageId, messageName,
                () => _handler.HandleAsync(@event, cancellationToken), cancellationToken);
        }

        return _handler.HandleAsync(@event, cancellationToken);
    }
}