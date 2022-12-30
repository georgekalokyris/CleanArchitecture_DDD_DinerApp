using CleanArchitecture_DDD_DinerApp.API.Filters;
using CleanArchitecture_DDD_DinerApp.API.Middleware;
using CleanArchitecture_DDD_DinerApp.Application;
using CleanArchitecture_DDD_DinerApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);
   // builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}