namespace Messaging.Shared.Contexts;

public interface IContextProvider
{
    IContext Current();
}
