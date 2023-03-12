using Messaging.Shared.Contexts.Accessors;
using Messaging.Shared.Contexts.Providers;
using Messaginh.Shared.Time;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Messaging.Shared.Contexts;

public static class Extensions
{
    public static IServiceCollection AddContexts(this IServiceCollection services)
    {
        services.AddSingleton<IClock, UtcClock>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSingleton<IContextProvider, ContextProvider>();
        services.AddSingleton<IContextAccessor, ContextAccessor>();

        return services;
    }
}