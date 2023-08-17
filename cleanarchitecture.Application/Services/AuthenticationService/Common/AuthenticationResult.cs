namespace cleanarchitecture.Application.Services.AuthenticationService.Common;
public record AuthenticationResult(
    User user,
    string Token
);