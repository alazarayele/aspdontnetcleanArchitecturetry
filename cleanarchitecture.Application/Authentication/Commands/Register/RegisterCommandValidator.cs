using cleanarchitecture.Application.Authentication.Commands.Register;
using FluentValidation;

namespace cleanarchitecture.Application.Authentication.Commands;


public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();

        }
    
}