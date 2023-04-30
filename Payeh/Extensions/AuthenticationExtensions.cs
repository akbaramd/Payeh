using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Payeh.Contracts;
using Payeh.Services;
using Payeh.Services.Contracts;

namespace Payeh.Extensions;

public static class AuthenticationExtensions
{
    public static IPayehBuilder AddJwtAuthentication(this IPayehBuilder builder, string audience, string issuer,
        string secret)
    {
        builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidIssuer = issuer
                };
            });

        builder.Services.AddSingleton<IJwtService>(new JwtService(audience, issuer, secret));
        return builder;
    }

    public static IPayehAppConfigure UseAuthentication(this IPayehAppConfigure app)
    {
        app.Application.UseAuthentication();
        return app;
    }

    public static IPayehAppConfigure UseAuthorization(this IPayehAppConfigure app)
    {
        app.Application.UseAuthorization();
        return app;
    }

    public static string UserId(this ClaimsPrincipal claimsPrincipal)
    {
        var userIdClaim = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid);
        if (userIdClaim == null)
        {
            throw new ArgumentNullException(nameof(userIdClaim));
        }

        return userIdClaim.Value;
    }
}