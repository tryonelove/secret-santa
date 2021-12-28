using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SecretSanta.Backend.DataAccess;
using SecretSanta.Backend.DomainModel;

namespace SecretSanta.Backend.Foundation;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddFoundation(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddDefaultIdentity<User>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();

        return services;
    }
}