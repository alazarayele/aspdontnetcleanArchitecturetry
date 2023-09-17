using System.Reflection;
using cleanarchitecture.Application.Authentication.Commands;
using cleanarchitecture.Application.Authentication.Commands.Register;
using cleanarchitecture.Application.Common.Behavior;
using cleanarchitecture.Application.Services.AuthenticationService.Common;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace cleanarchitecture.Application;

public static class ApplicationRegister
{
    public static IServiceCollection AddApplicationReg(this IServiceCollection iservice)
    {
        
        //iservice.AddMediatR(typeof(ApplicationRegister).Assembly);
    iservice.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(typeof(ApplicationRegister).GetTypeInfo().Assembly));
    iservice.AddScoped<IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>,
    ValidateRegisterCommandBehavior>();
       // iservice.AddScoped<IValidator<RegisterCommand>,RegisterCommandValidator>();
    iservice.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    return iservice;   
    }
}