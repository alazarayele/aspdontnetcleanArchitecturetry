using cleanarchitecture.Application.Common.Errors;

namespace cleanarchitecture.Application.Services.AuthenticationService;

public class AuthenticationService : IAuthenticationService
{
    
    private readonly IJwtTokenGenerator _iJwtTokenGenerator;
    private readonly IUserRepository _iUserRepository;
    
    public AuthenticationService(IJwtTokenGenerator ijwtTokenGenerator,IUserRepository iUserRepository)
    {
       _iJwtTokenGenerator= ijwtTokenGenerator;
       _iUserRepository = iUserRepository;
    }
   
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
       if (_iUserRepository.GetUserByEmail(email) is not null) 
       {
            throw new DeplicateEmailException();
       }
       var user =new User
       {
           FirstName = firstName,
           LastName = lastName,
           EMail = email,
           Password = password
       };

       _iUserRepository.Add(user);
       
        var token = _iJwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user,token);
    }
     public AuthenticationResult login(string email, string password)
    { 
        if(_iUserRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("email does not exist");
        }
        if(user.Password != password)
        {
            throw new Exception("Invalid Password");
        }
        var token = _iJwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
           user,
            token
            );
    }

}