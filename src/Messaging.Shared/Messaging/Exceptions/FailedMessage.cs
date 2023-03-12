using Messaging.Shared.Abstractions;

namespace Messaging.Shared.Messaging.Exceptions;

public record FailedMessage(IMessage Message);