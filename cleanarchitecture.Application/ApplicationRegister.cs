namespace cleanarchitecture.Application;

public static class ApplicationRegistration
{
    public static IServiceCollection AddApplicationRegistraion(this IServiceCollection iService)
    {
        iService.AddScoped<IAuthenticationService ,AuthenticationService>();
      
       

        return iService;
    }
}