﻿using Messaging.Shared.Abstractions;
using Messaging.Shared.Messaging;

namespace Messaging.Shared.Transactions.Outbox;

public interface IOutbox
{
    bool Enabled { get; }
    Task SaveAsync<T>(MessageEnvelope<T> message, CancellationToken cancellationToken = default) where T : IMessage;
    Task PublishUnsentAsync(CancellationToken cancellationToken = default);
    Task PublishAwaitingAsync(CancellationToken cancellationToken = default);
    Task CleanupAsync(DateTime? to = null, CancellationToken cancellationToken = default);
}