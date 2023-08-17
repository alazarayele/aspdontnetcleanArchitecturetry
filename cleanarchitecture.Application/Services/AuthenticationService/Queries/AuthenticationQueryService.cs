using cleanarchitecture.Application.Common.Errors;
using cleanarchitecture.Application.Services.AuthenticationService.Common;
using cleanarchitecture.Domain.Common.Errors;
using ErrorOr;

namespace cleanarchitecture.Application.Services.AuthenticationService.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    
    private readonly IJwtTokenGenerator _iJwtTokenGenerator;
    private readonly IUserRepository _iUserRepository;
    
    public AuthenticationQueryService(IJwtTokenGenerator ijwtTokenGenerator,IUserRepository iUserRepository)
    {
       _iJwtTokenGenerator= ijwtTokenGenerator;
       _iUserRepository = iUserRepository;
    }
   
    
     public AuthenticationResult login(string email, string password)
    { 
        if(_iUserRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("email does not exist");
        }
        if(user.Password != password)
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