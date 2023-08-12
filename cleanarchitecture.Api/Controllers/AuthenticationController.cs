using ErrorOr;

namespace cleanarchitecture.Api.Controllers;



[Route("auth")]

public class AuthenticationController : ApiController 
{

    private readonly IAuthenticationService _iAuthenticationService;
public AuthenticationController(IAuthenticationService iAuthenticationService)
{
    _iAuthenticationService=iAuthenticationService;
}

[HttpPost("register")]

public IActionResult Register(RegisterRequest request)
{ 
    ErrorOr<AuthenticationResult>authResult = _iAuthenticationService.Register(
    request.FirstName,
    request.LastName,
    request.Email,
    request.Password);
    
    return authResult.Match(
        authResult => Ok(MapAuthResult(authResult)),
        errors =>Problem(errors)
        
    );
 

 
}

private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
{
    return new AuthenticationResponse(
    authResult.user.Id,
    authResult.user.FirstName,
    authResult.user.LastName,
    authResult.user.EMail,
    authResult.Token 
   
   ) ;
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
  