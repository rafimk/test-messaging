using Messaging.Shared.Abstractions;
using Messaging.Shared.Contexts;
using Messaging.Shared.Messaging.Clients;

namespace Messaging.Shared.Messaging.Brokers;

internal sealed class MessageBroker : IMessageBroker
{
    private readonly IMessageBrokerClient _client;
    private readonly IContextProvider _contextProvider;

    public MessageBroker(IMessageBrokerClient client, IContextProvider contextProvider)
    {
        _client = client;
        _contextProvider = contextProvider;
    }

    public async Task SendAsync<T>(T message, CancellationToken cancellationToken = default) where T : IMessage
    {
        var messageId = Guid.NewGuid().ToString("N");
        var context = _contextProvider.Current();
        await _client.SendAsync(new MessageEnvelope<T>(message, new MessageContext(messageId, context)), cancellationToken);
    }
}