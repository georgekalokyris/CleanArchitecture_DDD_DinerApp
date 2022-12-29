using CleanArchitecture_DDD_DinerApp.Application.Common.Interfaces.Authentication;
using CleanArchitecture_DDD_DinerApp.Application.Common.Interfaces.Persistence;
using CleanArchitecture_DDD_DinerApp.Domain.Entities;

namespace CleanArchitecture_DDD_DinerApp.Application.Services.Authentication;
public class AuthenticationService : IAuthenticationService
{
    private readonly IjwtTokenGenerator _jwtTokenGenerator;

    private readonly IUserRepository _userRepository;
    public AuthenticationService(IjwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public AuthenticationResult Login(string email, string password)
    {
        //Validate the user exists
        if(_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with given email doesn't exist"); //In the real world this is dangerous - just there for dev purposes
        }
       
        //Validate the password is correct
        if(user.Password != password)
        {
            throw new Exception("Invalid password");
        }

        //Generate JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //Validate the user doesnt exist
        if(_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with given email already exists");
        }
        //Create user (generate unique ID) and persist to db
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        //Generate JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
