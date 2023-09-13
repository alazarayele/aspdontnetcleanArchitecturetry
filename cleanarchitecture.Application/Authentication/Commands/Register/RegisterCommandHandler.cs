namespace cleanarchitecture.Application.Authentication.Commands.Register;

using System.Threading;
using System.Threading.Tasks;
using cleanarchitecture.Application.Services.AuthenticationService.Common;
using cleanarchitecture.Domain.Common.Errors;
using ErrorOr;
using MediatR;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _iJwtTokenGenerator;
    private readonly IUserRepository _iUserRepository;
    
    public RegisterCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _iJwtTokenGenerator = jwtTokenGenerator;
        _iUserRepository = userRepository;
    }
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
         if (_iUserRepository.GetUserByEmail(command.Email) is not null) 
       {
            return Errors.User.DuplicateEmail;
       }
       var user =new User
       {
           FirstName = command.FirstName,
           LastName = command.LastName,
           EMail = command.Email,
           Password = command.Password
       };

       _iUserRepository.Add(user);
       
        var token = _iJwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user,token);
    }
}