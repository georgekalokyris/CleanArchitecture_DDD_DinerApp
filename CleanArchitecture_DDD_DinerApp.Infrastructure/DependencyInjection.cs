using CleanArchitecture_DDD_DinerApp.Application.Common.Authentication;
using CleanArchitecture_DDD_DinerApp.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture_DDD_DinerApp.Infrastructure;

//Each layer should register their own services so in case this get big each team will know where to look 
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IjwtTokenGenerator, jwtTokenGenerator>();

        return services;
    }
}