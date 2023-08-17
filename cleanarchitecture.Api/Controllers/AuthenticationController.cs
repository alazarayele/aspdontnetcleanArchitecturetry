using cleanarchitecture.Application.Services.AuthenticationService;
using cleanarchitecture.Application.Services.AuthenticationService.Common;
using cleanarchitecture.Application.Services.AuthenticationService.Queries;
using ErrorOr;
using MediatR;

namespace cleanarchitecture.Api.Controllers;



[Route("auth")]

public class AuthenticationController : ApiController 
{
    private readonly IMediator _mediator;
    private readonly IAuthenticationCommandService _iAuthenticationCommandService;
     private readonly IAuthenticationQueryService _iAuthenticationQueryService;
public AuthenticationController(IAuthenticationCommandService iAuthenticationCommandService,
IAuthenticationQueryService iAuthenticationQueryService)
{
    _iAuthenticationCommandService=iAuthenticationCommandService;
    _iAuthenticationQueryService=iAuthenticationQueryService;
}

[HttpPost("register")]

public IActionResult Register(RegisterRequest request)
{ 
    ErrorOr<AuthenticationResult>authResult = _iAuthenticationCommandService.Register(
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
    
    var authResult = _iAuthenticationQueryService.login(

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
  