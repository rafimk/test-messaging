using Messaging.Shared.Messaging.Brokers;

namespace Messaging.Shared.Messaging.Exceptions;

public record MessageExceptionPolicy(bool Retry, bool UseDeadLetter, Func<IMessageBroker, Task>? Publish = null);