namespace cleanarchitecture.Application.Services.AuthenticationService.Queries;

using cleanarchitecture.Application.Services.AuthenticationService.Common;
using ErrorOr;
public interface IAuthenticationQueryService
{
 AuthenticationResult login(string email,string password);
}