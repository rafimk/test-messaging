using Messaging.Shared.Abstractions;

namespace Messagintg.Shared.Handlers;

public interface ICommandDispatcher
{
    Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : class, ICommand;
}