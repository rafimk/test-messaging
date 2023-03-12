using Messaging.Shared.Abstractions;
using Messaging.Shared.Attributes;

namespace Messaging.Subscriber.Events.External;

[Message("customers", "customer_created", "orders.customer_created")]
public record CustomerCreated(Guid Id, string Name) : IEvent;