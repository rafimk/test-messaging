using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;

namespace Messaginh.Shared.Serialization;

public static class Extensions
{
    public static IServiceCollection AddSerializer(this IServiceCollection services)
    {
        services.AddSingleton<IJsonSerializer, SystemTextJsonSerializer>();

        return services;
    }
}