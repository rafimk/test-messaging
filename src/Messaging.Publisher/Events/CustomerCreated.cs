using Messaging.Shared.Abstractions;
using Messaging.Shared.Attributes;

namespace Messaging.Publisher.Events;

[Message("customers", "customer_created")]
public record CustomerCreated(Guid Id, string Name) : IEvent;