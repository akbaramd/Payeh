using Payeh.Common.Exceptions.Core;

namespace Payeh.Common.Exceptions;

public class IsNullException : CoreException
{
    public IsNullException(string message , string? errorCode = nameof(IsNullException), object? parameters = null) : base(message, errorCode, parameters)
    {
    }
}