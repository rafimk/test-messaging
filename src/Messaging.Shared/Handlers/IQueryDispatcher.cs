using Messaging.Shared.Abstractions;

namespace Messaging.Shared.Handlers;

public interface IQueryDispatcher
{
    Task<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
}