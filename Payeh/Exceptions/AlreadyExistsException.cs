using Payeh.Exceptions.Core;

namespace Payeh.Exceptions;

public class AlreadyExistsException : CoreException
{
    public AlreadyExistsException(string message , string? errorCode = nameof(AlreadyExistsException), object? parameters = null) : base(message, errorCode, parameters)
    {
    }
}