using Messaging.Shared.Abstractions;
using Messaging.Shared.Handlers;
using Messagintg.Shared.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Messaging.Shared.Dispatchers;

internal sealed class InMemoryCommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public InMemoryCommandDispatcher(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public async Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : class, ICommand
    {
        if (command is null)
        {
            throw new InvalidOperationException("Command cannot be null.");
        }

        await using var scope = _serviceProvider.CreateAsyncScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();
        await handler.HandleAsync(command, cancellationToken);
    }
}