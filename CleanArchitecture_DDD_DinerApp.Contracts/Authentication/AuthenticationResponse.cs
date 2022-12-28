namespace CleanArchitecture_DDD_DinerApp.Contracts.Authentication;
public record AuthenticationResponse
(
Guid Id,
string FirstName,
string LastName,
string Email,
string Token
);