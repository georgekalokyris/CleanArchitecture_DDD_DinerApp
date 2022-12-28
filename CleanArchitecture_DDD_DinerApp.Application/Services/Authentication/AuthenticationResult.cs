namespace CleanArchitecture_DDD_DinerApp.Application.Services.Authentication;

//We don't want the contracts to be leaking into the application as it will be cause issues when maintaining extending the app.
public record AuthenticationResult(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token
    );

