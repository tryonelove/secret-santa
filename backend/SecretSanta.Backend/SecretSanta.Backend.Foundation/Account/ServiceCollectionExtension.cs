using Microsoft.Extensions.DependencyInjection;
using SecretSanta.Backend.DataAccess;
using SecretSanta.Backend.DomainModel;

namespace SecretSanta.Backend.Foundation.Account;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddSecurity(this IServiceCollection services)
    {
        services.AddDefaultIdentity<User>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        return services;
    }
}