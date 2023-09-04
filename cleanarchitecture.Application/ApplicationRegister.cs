using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace cleanarchitecture.Application;

public static class ApplicationRegister
{
    public static IServiceCollection AddApplicationReg(this IServiceCollection iservice)
    {
        
        //iservice.AddMediatR(typeof(ApplicationRegister).Assembly);
         iservice.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(typeof(ApplicationRegister).GetTypeInfo().Assembly));
        return iservice;   
    }
}