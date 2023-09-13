using cleanarchitecture.Application.Authentication.Commands.Register;
using cleanarchitecture.Application.Authentication.Queries.Login;
using cleanarchitecture.Application.Services.AuthenticationService.Common;
using Mapster;

namespace cleanarchitecture.Api.Common.Mapping;


public class AuthenticationMappingConfig : IRegister
{

    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
        .Map(dest => dest.Token,src => src.Token)
        .Map(dest => dest,src => src.user);
    }
}