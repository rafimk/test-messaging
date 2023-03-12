namespace Messaging.Shared.Postgres;

public interface IDataInitializer
{
    Task InitAsync();
}