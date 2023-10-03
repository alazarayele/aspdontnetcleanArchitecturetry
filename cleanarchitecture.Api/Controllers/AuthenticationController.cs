using cleanarchitecture.Application.Authentication.Commands.Register;
using cleanarchitecture.Application.Authentication.Queries.Login;
using cleanarchitecture.Application.Services.AuthenticationService;
using cleanarchitecture.Application.Services.AuthenticationService.Common;

using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace cleanarchitecture.Api.Controllers;



[Route("auth")]
[AllowAnonymous]

public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;

    private readonly IMapper _mapper;


    public AuthenticationController(ISender mediator,IMapper mapper )
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    [HttpPost("register")]

    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
         
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors)

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

       );
    }


    [HttpPost("login")]



    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
      
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);
        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors)
        );
    }

    // public async Task<IActionResult> Login(LoginRequest request)
    // {
    //     var query = new LoginQuery(request.Email,request.Password);
    //     var authResult =await _mediator.Send(query);


    //    //var response = new AuthenticationResponse(authResult.User);

    //    return Ok("FailedLogin");
    // }
   



}
