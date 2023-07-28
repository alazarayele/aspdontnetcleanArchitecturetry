namespace cleanarchitecture.Infrastructure.Authentication;





public class JwtTokenGenerator : IJwtTokenGenerator
{
 private readonly IDateTimeProvider _dateTimeProvider;
 private readonly JwtSettings _jwtSettings;   

 public JwtTokenGenerator(IDateTimeProvider dateTimeProvider,IOptions<JwtSettings> jwtOptions)
 {
    _dateTimeProvider=dateTimeProvider;
    _jwtSettings = jwtOptions.Value;
 }
    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256);
             
            
        
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName,user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName,user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
        
        };
        var SecurityToken = new JwtSecurityToken(
            claims: claims,
            issuer:_jwtSettings.Issuer,
            audience:_jwtSettings.Audience,
            expires:_dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpirationTimeInMinutes),
            signingCredentials:signingCredentials);
    return new JwtSecurityTokenHandler().WriteToken(SecurityToken);
    }
}