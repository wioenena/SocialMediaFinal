using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SocialMediaFinal.Backend.Application.Options;

namespace SocialMediaFinal.Backend.API.Configurations;

public static class JWTConfigurations {
    public static IServiceCollection ApplyJWTConfiguration(this IServiceCollection services, bool isDevelopment) {
        _ = services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o => {
            var jwtOptions = services.BuildServiceProvider().GetRequiredService<IOptions<JWTOptions>>().Value;

            o.RequireHttpsMetadata = !isDevelopment;
            o.SaveToken = true;
            o.TokenValidationParameters = new() {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtOptions.Issuer,
                ValidAudience = jwtOptions.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Secret)),
                ClockSkew = TimeSpan.Zero,
            };
        });

        _ = services.AddAuthorization();
        return services;
    }
}
