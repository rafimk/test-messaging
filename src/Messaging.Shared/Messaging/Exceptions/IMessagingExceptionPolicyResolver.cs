using Messaging.Shared.Abstractions;

namespace Messaging.Shared.Messaging.Exceptions;

public interface IMessagingExceptionPolicyResolver
{
    MessageExceptionPolicy? Resolve(IMessage message, Exception exception);
}