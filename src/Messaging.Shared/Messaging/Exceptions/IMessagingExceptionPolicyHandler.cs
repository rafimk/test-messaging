using Messaging.Shared.Abstractions;

namespace Messaging.Shared.Messaging.Exceptions;

public interface IMessagingExceptionPolicyHandler
{
    Task HandleAsync<T>(T message, Func<Task> handler) where T : IMessage;
}