using CleanArchitecture_DDD_DinerApp.Application.Common.Interfaces.Authentication;

namespace CleanArchitecture_DDD_DinerApp.Application.Services.Authentication;
public class AuthenticationService : IAuthenticationService
{
    private readonly IjwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IjwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public AuthenticationResult Login(string email, string password)
    {

        //Generate JWT token
        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, email, password);
        return new AuthenticationResult(Guid.NewGuid() , "firstName", "lastName", email, token);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //Check if user already exists

        //Create user (generate uniqueId)

        //Generate JWT token
        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

        return new AuthenticationResult(userId, firstName, lastName, email, token);
    }
}
