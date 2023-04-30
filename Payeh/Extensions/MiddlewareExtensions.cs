using Microsoft.AspNetCore.Builder;
using Payeh.Middlewares;

namespace Payeh.Extensions;

public static class MiddlewareExtensions
{
    public static void UsApiExceptionHandlerMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ApiExceptionHandlerMiddleware>();
    }
}