using Messaging.Shared.Abstractions;

namespace Messaging.Publisher.Commands;

public record CreateCustomer(Guid Id, string Name) : ICommand;