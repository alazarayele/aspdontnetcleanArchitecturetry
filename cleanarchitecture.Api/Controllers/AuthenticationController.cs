namespace aspdotnetcleanarchitecturetry.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using aspdotnetcleanarchitecturetry.Contracts.Authentication;
using cleanarchitecture.Application.Services.AuthenticationService;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase 
{

    private readonly IAuthenticationService _iAuthenticationService;
public AuthenticationController(IAuthenticationService iAuthenticationService)
{
    _iAuthenticationService=iAuthenticationService;
}

[HttpPost("register")]

public IActionResult Register(RegisterRequest request)
{ 
    var authResult = _iAuthenticationService.Register(
    request.FirstName,
    request.LastName,
    request.Email,
    request.Password);
    

   var response = new AuthenticationResponse(
    authResult.Id,
    authResult.FirstName,
    authResult.LirstName,
    authResult.Email,
    authResult.Token 
   ) ;

   return Ok(response);
}


[HttpPost("login")]

public IActionResult Login(LoginRequest request)
{
    
    var authResult = _iAuthenticationService.login(

    request.Email,
    request.Password);
    

   var response = new AuthenticationResponse(
    authResult.Id,
    authResult.FirstName,
    authResult.LirstName,
    authResult.Email,
    authResult.Token 
   ) ;

   return Ok(response);
}

}
  