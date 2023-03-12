using Messaging.Shared.Abstractions;
using Messaging.Shared.Contexts;

namespace Messaging.Shared.Messaging;

public record MessageEnvelope<T>(T Message, MessageContext Context) where T : IMessage;