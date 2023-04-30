using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Payeh.Services.Contracts;

namespace Payeh.Services;

public class JwtService : IJwtService
{

    private readonly string _audience;
    private readonly string _issuer;
    private readonly string _secret;

    public JwtService(string audience, string issuer, string secret)
    {
        _audience = audience;
        _issuer = issuer;
        _secret = secret;
    }

    public string Generate(string userId , List<Claim>? claims)
    {
        claims = claims ?? new List<Claim>();
        claims.Add(new Claim(ClaimTypes.Sid,userId));
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(),
            Expires = DateTime.UtcNow.AddDays(7),
            Issuer = _issuer,
            Audience = _audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);
        return tokenString;
    }
}