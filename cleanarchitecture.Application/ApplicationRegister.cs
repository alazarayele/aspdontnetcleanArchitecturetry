
using cleanarchitecture.Application.Services.AuthenticationService.Queries;

namespace cleanarchitecture.Application;

public static class ApplicationRegister
{
    public static IServiceCollection AddApplicationReg(this IServiceCollection iservice)
    {
        
        iservice.AddSingleton<IAuthenticationCommandService, AuthenticationCommandService>();
        iservice.AddSingleton<IAuthenticationQueryService,AuthenticationQueryService>();
        return iservice;   
    }
}