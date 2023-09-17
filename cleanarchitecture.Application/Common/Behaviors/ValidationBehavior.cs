namespace cleanarchitecture.Application.Common.Behavior;

using System.Threading;
using System.Threading.Tasks;
using cleanarchitecture.Application.Authentication.Commands.Register;
using cleanarchitecture.Application.Services.AuthenticationService.Common;
using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.JSInterop.Infrastructure;

public class ValidateRegisterCommandBehavior : IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IValidator<RegisterCommand> _validator;

    public ValidateRegisterCommandBehavior(IValidator<RegisterCommand> validator)
    {
        _validator=validator;
    }
    public async Task<ErrorOr<AuthenticationResult>> Handle(
        RegisterCommand request,
         RequestHandlerDelegate<ErrorOr<AuthenticationResult>> next, 
         CancellationToken cancellationToken)
    {
        //before the handler
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if(validationResult.IsValid)
        {
            return await next();
        }

        //after the handler

        var errors = validationResult.Errors
        .ConvertAll(ValidationFailure => Error.Validation(ValidationFailure.PropertyName, ValidationFailure.ErrorMessage))
        ;
        return errors;
    }
}