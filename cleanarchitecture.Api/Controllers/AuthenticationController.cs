namespace cleanarchitecture.Api.Controllers;


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
    authResult.user.Id,
    authResult.user.FirstName,
    authResult.user.LastName,
    authResult.user.EMail,
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
    authResult.user.Id,
    authResult.user.FirstName,
    authResult.user.LastName,
    authResult.user.EMail,
    authResult.Token 
   ) ;

   return Ok(response);
}

}
  