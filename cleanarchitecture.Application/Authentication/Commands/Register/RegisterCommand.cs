using cleanarchitecture.Application.Services.AuthenticationService.Common;
using ErrorOr;
using MediatR;

namespace cleanarchitecture.Application.Authentication.Commands.Register;

public record RegisterCommand(
string FirstName,
string LastName,
string Email,
string Password):IRequest<ErrorOr<AuthenticationResult>>;