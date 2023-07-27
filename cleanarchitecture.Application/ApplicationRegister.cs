
namespace cleanarchitecture.Application;

public static class ApplicationRegister
{
    public static IServiceCollection AddApplicationReg(this IServiceCollection iservice)
    {
        
        iservice.AddSingleton<IAuthenticationService, AuthenticationService>();
        return iservice;   
    }
}