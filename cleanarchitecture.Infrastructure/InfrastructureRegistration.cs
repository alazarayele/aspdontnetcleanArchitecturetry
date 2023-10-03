using cleanarchitecture.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;

namespace cleanarchitecture.Infrastructure;

public static class InfrastructureReg
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection iservice,ConfigurationManager configuration)
    {
        iservice.AddAuth(configuration);
   iservice.AddSingleton<IDateTimeProvider,DateTimeProvider>();
        iservice.AddSingleton<IUserRepository,UserRepository>();
        return iservice;   
    }

    public static IServiceCollection AddAuth(
        this IServiceCollection iservice,
        ConfigurationManager configuration
    )
    {
        var JwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName,JwtSettings);
        iservice.AddSingleton(Options.Create(JwtSettings));
        iservice.AddSingleton<IJwtTokenGenerator,JwtTokenGenerator>();
       
        iservice.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme).
        AddJwtBearer(Options => Options.TokenValidationParameters = new TokenValidationParameters
                      {
                           ValidateIssuer = true,
                           ValidateAudience = true,
                           ValidateLifetime = true,
                           ValidateIssuerSigningKey = true,
                           ValidIssuer = JwtSettings.Issuer,
                           ValidAudience = JwtSettings.Audience,
                           IssuerSigningKey = new SymmetricSecurityKey(
                              Encoding.UTF8.GetBytes(JwtSettings.Secret))
                       }
       );  

       return iservice; 
    }
}