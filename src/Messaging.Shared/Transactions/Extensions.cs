using Messaging.Shared.Handlers;
using Messaging.Shared.Transactions.Decorators;
using Microsoft.Extensions.DependencyInjection;

namespace Messaging.Shared.Transactions;

public static class Extensions
{
    public static IServiceCollection AddTransactionalDecorators(this IServiceCollection services)
    {
        services.TryDecorate(typeof(ICommandHandler<>), typeof(TransactionalCommandHandlerDecorator<>));
        services.TryDecorate(typeof(IEventHandler<>), typeof(TransactionalEventHandlerDecorator<>));

        return services;
    }
    
    public static IServiceCollection AddOutboxInstantSenderDecorators(this IServiceCollection services)
    {
        services.TryDecorate(typeof(ICommandHandler<>), typeof(OutboxInstantSenderCommandHandlerDecorator<>));
        services.TryDecorate(typeof(IEventHandler<>), typeof(OutboxInstantSenderEventHandlerDecorator<>));

        return services;
    }
}