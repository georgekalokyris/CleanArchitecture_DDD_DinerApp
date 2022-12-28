using CleanArchitecture_DDD_DinerApp.Application.Services.Authentication;
using CleanArchitecture_DDD_DinerApp.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture_DDD_DinerApp.API.Controllers;
[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest registerRequest)
    {
        var authResult = _authenticationService.Register(registerRequest.FirstName,
                                                         registerRequest.LastName,
                                                         registerRequest.Email,
                                                         registerRequest.Password);
        var response = new AuthenticationResponse(authResult.Id, authResult.FirstName, authResult.LastName, authResult.Email, authResult.Token);

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest loginRequest)
    {
        var authResult = _authenticationService.Login(loginRequest.Email,
                                                      loginRequest.Password);

        var response = new AuthenticationResponse(authResult.Id, authResult.FirstName, authResult.LastName, authResult.Email, authResult.Token);

        return Ok(response);
    }

}
