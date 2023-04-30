using Payeh.Exceptions.Core;

namespace Payeh.Exceptions;

public class IsNullException : CoreException
{
    public IsNullException(string message , string? errorCode = nameof(IsNullException), object? parameters = null) : base(message, errorCode, parameters)
    {
    }
}