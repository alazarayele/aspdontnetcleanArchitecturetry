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

public class ValidateRegisterCommandBehavior<TRequest, TResponse> :
 IPipelineBehavior<TRequest, TResponse>
where TRequest : IRequest<TResponse>
where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    public ValidateRegisterCommandBehavior(IValidator<TRequest>? validator)
    {
        _validator=validator;
    }
    public async Task<TResponse> Handle(
        TRequest request,
         RequestHandlerDelegate<TResponse> next, 
         CancellationToken cancellationToken)
    {

        if (_validator is null)
        {
            return await next();
        }
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
        return (dynamic)errors;
    }
}