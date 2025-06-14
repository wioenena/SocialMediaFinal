using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using SocialMediaFinal.Backend.Application.Interfaces.Services;
using SocialMediaFinal.Backend.Application.Options;
using System.IdentityModel.Tokens.Jwt;

namespace SocialMediaFinal.Backend.Application.Services;

public sealed class JWTService(IOptions<JWTOptions> jwtOptions) : IJWTService {
    private readonly IOptions<JWTOptions> jwtOptions = jwtOptions;
    public string GenerateAccessToken(string accountId) {
        var secret = this.jwtOptions.Value.Secret;
        var issuer = this.jwtOptions.Value.Issuer;
        var audience = this.jwtOptions.Value.Audience;

        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(secret));
        JwtSecurityToken jwtToken = new(
            issuer: issuer,
            audience: audience,
            claims: [new("id", accountId)],
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: new(securityKey, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(jwtToken);
    }
}
