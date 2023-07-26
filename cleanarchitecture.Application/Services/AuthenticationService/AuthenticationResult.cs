namespace cleanarchitecture.Application.Services.AuthenticationService;
public record AuthenticationResult(
    Guid Id,
    string FirstName,
    string LirstName,
    string Email,
    string Token
);