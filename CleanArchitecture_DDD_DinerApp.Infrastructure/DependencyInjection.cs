using CleanArchitecture_DDD_DinerApp.Application.Common.Interfaces.Authentication;
using CleanArchitecture_DDD_DinerApp.Application.Common.Interfaces.Services;
using CleanArchitecture_DDD_DinerApp.Infrastructure.Authentication;
using CleanArchitecture_DDD_DinerApp.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture_DDD_DinerApp.Infrastructure;

//Each layer should register their own services so in case this get big each team will know where to look 
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                                                       ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IjwtTokenGenerator, jwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}