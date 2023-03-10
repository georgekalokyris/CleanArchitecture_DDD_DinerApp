using System.Net;
using System.Text.Json;

namespace CleanArchitecture_DDD_DinerApp.API.Middleware;
public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExeptionAsync(context, ex);
        }
    }

    private Task HandleExeptionAsync(HttpContext context, Exception ex)
    {
        var code = HttpStatusCode.InternalServerError; //500 if unexpected
        var result = JsonSerializer.Serialize(new { error = "An error occured while processing your request." });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(result);
    }

}
