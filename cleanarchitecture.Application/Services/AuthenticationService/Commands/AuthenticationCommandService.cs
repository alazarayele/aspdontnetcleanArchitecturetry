using cleanarchitecture.Application.Common.Errors;
using cleanarchitecture.Application.Services.AuthenticationService.Common;
using cleanarchitecture.Domain.Common.Errors;
using ErrorOr;

namespace cleanarchitecture.Application.Services.AuthenticationService.Commands;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    
    private readonly IJwtTokenGenerator _iJwtTokenGenerator;
    private readonly IUserRepository _iUserRepository;
    
    public AuthenticationCommandService(IJwtTokenGenerator ijwtTokenGenerator,IUserRepository iUserRepository)
    {
       _iJwtTokenGenerator= ijwtTokenGenerator;
       _iUserRepository = iUserRepository;
    }
   
    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
       if (_iUserRepository.GetUserByEmail(email) is not null) 
       {
            return Errors.User.DuplicateEmail;
       }
       var user =new User
       {
           FirstName = firstName,
           LastName = lastName,
           EMail = email,
           Password = password
       };

       _iUserRepository.Add(user);
       
        var token = _iJwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user,token);
    }
     
}