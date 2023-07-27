namespace cleanarchitecture.Application.Services.AuthenticationService;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _iJwtTokenGenerator;

    
    public AuthenticationService(IJwtTokenGenerator ijwtTokenGenerator)
    {
       _iJwtTokenGenerator= ijwtTokenGenerator;
    }
   Guid userId = Guid.NewGuid();
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        
        var token = _iJwtTokenGenerator.GenerateToken(userId,firstName,lastName);
        return new AuthenticationResult(Guid.NewGuid(),firstName,lastName,email,token);
    }
     public AuthenticationResult login(string email, string password)
    { 
        var token = _iJwtTokenGenerator.GenerateToken(userId,email,password);
        return new AuthenticationResult(
            userId,
           "firstName",
            "lastname",
            email,
            token
            );
    }

}