namespace Messaging.Shared.Contexts.Accessors;

public interface IMessageContextAccessor
{
    MessageContext? MessageContext { get; set; }
}