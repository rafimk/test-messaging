﻿using Messaging.Shared.Abstractions;
using Messaging.Shared.Attributes;
using Messaging.Shared.Handlers;
using Messaginh.Shared.Postgres;

namespace Messaging.Shared.Transactions.Decorators;

[Decorator]
internal sealed class TransactionalCommandHandlerDecorator<T> : ICommandHandler<T> where T : class, ICommand
{
    private readonly ICommandHandler<T> _handler;
    private readonly IUnitOfWork _unitOfWork;

    public TransactionalCommandHandlerDecorator(ICommandHandler<T> handler, IUnitOfWork unitOfWork)
    {
        _handler = handler;
        _unitOfWork = unitOfWork;
    }

    public Task HandleAsync(T command, CancellationToken cancellationToken = default)
        => _unitOfWork.ExecuteAsync(() => _handler.HandleAsync(command, cancellationToken), cancellationToken);
}