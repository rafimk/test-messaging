using Messaging.Shared.Abstractions;

namespace Messaging.Shared.Handlers;

public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
{
    Task HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}