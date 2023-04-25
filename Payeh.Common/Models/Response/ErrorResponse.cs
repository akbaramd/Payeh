namespace Payeh.Common.Models.Response;

public class ErrorResponse
{
    public ErrorResponse(string? code, string message, object? parameters)
    {
        Code = code;
        Message = message;
        Parameters = parameters;
    }

    public string? Code { get; set; }
    public string Message { get; set; }
    public object? Parameters { get; set; }
}