using System.Reflection;
using EasyNetQ;
using Messaging.Shared.Abstractions;
using Messaging.Shared.Attributes;
using Messaging.Shared.Handlers;
using Messaging.Shared.Messaging.Subscribers;
using Messaginh.Shared.RabbitMQ.Internals;
using Microsoft.Extensions.DependencyInjection;
using IMessage = Messaging.Shared.Abstractions.IMessage;

namespace Messaginh.Shared.RabbitMQ;

internal sealed class RabbitMqMessageSubscriber : IMessageSubscriber
{
    private readonly IMessageHandler _messageHandler;
    private readonly IMessageTypeRegistry _messageTypeRegistry;
    private readonly IBus _bus;

    public RabbitMqMessageSubscriber(IMessageHandler messageHandler, IMessageTypeRegistry messageTypeRegistry, IBus bus)
    {
        _messageHandler = messageHandler;
        _messageTypeRegistry = messageTypeRegistry;
        _bus = bus;
    }

    public IMessageSubscriber Command<T>() where T : class, ICommand
        => Message<T>((serviceProvider, command, cancellationToken) =>
            serviceProvider.GetRequiredService<IDispatcher>().SendAsync(command, cancellationToken));

    public IMessageSubscriber Event<T>() where T : class, IEvent
        => Message<T>((serviceProvider, @event, cancellationToken) =>
            serviceProvider.GetRequiredService<IDispatcher>().PublishAsync(@event, cancellationToken));

    public IMessageSubscriber Message<T>(Func<IServiceProvider, T, CancellationToken, Task> handler)
        where T : class, IMessage
    {
        _messageTypeRegistry.Register<T>();
        var messageAttribute = typeof(T).GetCustomAttribute<MessageAttribute>() ?? new MessageAttribute();

        _bus.PubSub.SubscribeAsync<T>(messageAttribute.SubscriptionId,
            (message, cancellationToken) => _messageHandler.HandleAsync(handler, message, cancellationToken),
            configuration =>
            {
                var topic = string.IsNullOrWhiteSpace(messageAttribute.Topic)
                    ? typeof(T).Name.ToMessageKey()
                    : messageAttribute.Topic;

                configuration.WithTopic(topic);
            });

        return this;
    }
}