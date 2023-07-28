namespace cleanarchitecture.Application.Services.AuthenticationService;
public record AuthenticationResult(
    User user,
    string Token
);