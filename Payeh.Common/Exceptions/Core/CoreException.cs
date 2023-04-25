namespace Payeh.Common.Exceptions.Core;

public class CoreException : Exception
{
    
    public string? ErrorCode { get; set; }
    public object? Parameters { get; set; }

    public CoreException(string message , string? errorCode = "Global" , object? parameters = null):base(message)
    {
        ErrorCode = errorCode;
        Parameters = parameters;
    }
}