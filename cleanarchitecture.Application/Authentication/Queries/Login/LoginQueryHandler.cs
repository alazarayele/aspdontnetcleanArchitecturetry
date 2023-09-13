namespace cleanarchitecture.Application.Authentication.Commands.Login;

using System.Threading;
using System.Threading.Tasks;
using cleanarchitecture.Application.Authentication.Queries.Login;

using cleanarchitecture.Application.Services.AuthenticationService.Common;
using cleanarchitecture.Domain.Common.Errors;
using ErrorOr;
using MediatR;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _iJwtTokenGenerator;
    private readonly IUserRepository _iUserRepository;
    
    public LoginQueryHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _iJwtTokenGenerator = jwtTokenGenerator;
        _iUserRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
         if(_iUserRepository.GetUserByEmail(query.Email) is not User user)
        {
            throw new Exception("email does not exist");
        }
        if(user.Password != query.Password)
        {
            throw new Exception("Invalid Password");
        }
        var token = _iJwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
           user,
            token
            );
    }
}