namespace cleanarchitecture.Application.Services.AuthenticationService;

public class AuthenticationService : IAuthenticationService
{
  
    public AuthenticationResult login(string email, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(),
            "firstname",
            "lastname",
            email,
            "Token"
            );
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(),firstName,lastName,email,"Token");
    }
}