using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Payeh.Common.Middlewares;

namespace Payeh.Common.Extensions;

public static class MiddlewareExtensions
{
    public static void UsApiExceptionHandlerMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ApiExceptionHandlerMiddleware>();
    }
}