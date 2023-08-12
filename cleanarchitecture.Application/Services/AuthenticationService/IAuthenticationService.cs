namespace cleanarchitecture.Application.Services.AuthenticationService;
using ErrorOr;
public interface IAuthenticationService
{
 ErrorOr<AuthenticationResult> Register(string firstName,string lastName,string email,string password);
 AuthenticationResult login(string email,string password);
}