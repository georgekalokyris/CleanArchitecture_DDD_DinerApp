using CleanArchitecture_DDD_DinerApp.Application.Common.Interfaces.Authentication;
using CleanArchitecture_DDD_DinerApp.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture_DDD_DinerApp.Application;

//Each layer should register their own services so in case this get big each team will know where to look 
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
       services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}
