using cleanarchitecture.Application.Authentication.Queries.Login;
using FluentValidation;

namespace cleanarchitecture.Application.Authentication.Queries;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{

    public LoginQueryValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}