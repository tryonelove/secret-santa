using Microsoft.Extensions.DependencyInjection;

namespace SecretSanta.Backend.Foundation;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>();

        return services;
    }
}