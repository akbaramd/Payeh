using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Payeh.Extensions;

public static class SwaggerExtensions
{
    public static void AddJwtBearerAuthentication(this SwaggerGenOptions options , string name ="Authorization" , string description = "Please insert JWT with Bearer into field" )
    {
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
            In = ParameterLocation.Header, 
            Description = description,
            Name = name,
            Type = SecuritySchemeType.ApiKey 
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement {
            { 
                new OpenApiSecurityScheme 
                { 
                    Reference = new OpenApiReference 
                    { 
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer" 
                    } 
                },
                Array.Empty<string>()
            } 
        });
    }

   
    
}