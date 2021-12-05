using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SecretSanta.Backend.DataAccess;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, Action<DataAccessOptions> optionsAction)
    {
        var dataAccessOptions = new DataAccessOptions();
        optionsAction.Invoke(dataAccessOptions);

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(dataAccessOptions.ConnectionString));

        return services;
    }
}