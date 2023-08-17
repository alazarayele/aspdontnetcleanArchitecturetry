namespace cleanarchitecture.Application.Services.AuthenticationService.Commands;

using cleanarchitecture.Application.Services.AuthenticationService.Common;
using ErrorOr;
public interface IAuthenticationCommandService
{
 ErrorOr<AuthenticationResult> Register(string firstName,string lastName,string email,string password);

}