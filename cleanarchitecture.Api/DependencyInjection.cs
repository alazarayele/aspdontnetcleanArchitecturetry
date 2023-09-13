using System.Reflection;
using cleanarchitecture.Api.Common.Mapping;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace cleanarchitecture.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection iservice)
    {
        
        //iservice.AddMediatR(typeof(ApplicationRegister).Assembly);
         iservice.AddMappings();
                return iservice;   
    }
}