using Messaging.Shared.Abstractions;

namespace Messaging.Shared.Messaging.Exceptions;

internal sealed class DefaultMessagingExceptionPolicyResolver : IMessagingExceptionPolicyResolver
{
    public MessageExceptionPolicy? Resolve(IMessage message, Exception exception) => null;
}