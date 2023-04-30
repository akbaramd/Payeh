using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Payeh.Exceptions;
using Payeh.Exceptions.Core;
using Payeh.Models.Response;

namespace Payeh.Middlewares;

public abstract class ApiExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    protected ApiExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var statusCode = HttpStatusCode.InternalServerError; 
        // Default to 500 Internal Server Error
        var message = ex.Message;
        var errorCode = "Global";
        object? parameters = null; 

        switch (ex)
        {
            case NotFoundException exception:
                statusCode = HttpStatusCode.NotFound;
                errorCode = exception.ErrorCode;
                parameters = exception.Parameters;
                break;
            
            case AlreadyExistsException exception:
                statusCode = HttpStatusCode.Conflict;
                errorCode = exception.ErrorCode;
                parameters = exception.Parameters;
                break;
            
            case IsNullException exception:
                statusCode = HttpStatusCode.Forbidden;
                errorCode = exception.ErrorCode;
                parameters = exception.Parameters;
                break;
            
            case CoreException exception:
                statusCode = HttpStatusCode.InternalServerError;
                errorCode = exception.ErrorCode;
                parameters = exception.Parameters;
                break;
            
            case ValidationException:
                statusCode = HttpStatusCode.BadRequest;
                errorCode = "Validation";
                break;
        }

        var response = new ErrorResponse(errorCode, message, parameters);
       
        var result = JsonConvert.SerializeObject(response);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;
        return context.Response.WriteAsync(result);
    }
}