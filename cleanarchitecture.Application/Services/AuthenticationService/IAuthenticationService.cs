namespace cleanarchitecture.Application.Services.AuthenticationService;
public interface IAuthenticationService
{
 AuthenticationResult Register(string firstName,string lastName,string email,string password);
 AuthenticationResult login(string email,string password);
}