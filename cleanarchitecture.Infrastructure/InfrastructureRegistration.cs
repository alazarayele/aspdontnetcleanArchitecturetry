 using cleanarchitecture.Infrastructure.Persistence;
using cleanarchitecture.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace cleanarchitecture.Infrastructure;

public static class InfrastructureReg
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection iservice,ConfigurationManager configuration)
    {
        iservice.AddAuth(configuration).AddPersistance();
   iservice.AddSingleton<IDateTimeProvider,DateTimeProvider>();
           return iservice;   
    }

 public static IServiceCollection AddPersistance(
        this IServiceCollection iservice )
    {   
        iservice.AddDbContext<CleanArchitectureDbContext>(options =>
        options.UseSqlServer("Server = localhost;Database =cleanarchitectureUser Id =SA;password = alazar123;TrustServerCertificatetrue"));
        iservice.AddSingleton<IUserRepository,UserRepository>();
        iservice.AddSingleton<IMenuRepository,MenuRepository>();
        return iservice;
    }
      
    public static IServiceCollection AddAuth(
        this IServiceCollection iservice,
        ConfigurationManager configuration
    )
    {
        var JwtSettings  = new JwtSettings();
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