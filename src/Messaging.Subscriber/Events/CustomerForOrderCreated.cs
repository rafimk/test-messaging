using Messaging.Shared.Abstractions;
using Messaging.Shared.Attributes;

namespace Messaging.Subscriber.Events;

[Message("orders", "customer_for_order_created")]
public record CustomerForOrderCreated(Guid Id, string Name) : IEvent;