using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture_DDD_DinerApp.Infrastructure;

//Each layer should register their own services so in case this get big each team will know where to look 
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services;
    }
}