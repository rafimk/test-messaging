﻿using Messaging.Shared.Abstractions;

namespace Messaging.Shared.Messaging.Brokers;

public interface IMessageBroker
{
    Task SendAsync<T>(T message, CancellationToken cancellationToken = default) where T : IMessage;
}