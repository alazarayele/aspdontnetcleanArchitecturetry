using Microsoft.Extensions.Configuration;

namespace cleanarchitecture.Infrastructure;

public static class InfrastructureReg
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection iservice,IConfiguration configuration)
    {
        iservice.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        iservice.AddSingleton<IJwtTokenGenerator,JwtTokenGenerator>();
        iservice.AddSingleton<IDateTimeProvider,DateTimeProvider>();
        return iservice;   
    }
}