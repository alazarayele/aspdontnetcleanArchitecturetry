using cleanarchitecture.Application.Services.AuthenticationService.Common;
using ErrorOr;
using MediatR;

namespace cleanarchitecture.Application.Authentication.Queries.Login;

public record LoginQuery(
string Email,
string Password):IRequest<ErrorOr<AuthenticationResult>>;