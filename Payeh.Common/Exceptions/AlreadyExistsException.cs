using Payeh.Common.Exceptions.Core;

namespace Payeh.Common.Exceptions;

public class AlreadyExistsException : CoreException
{
    public AlreadyExistsException(string message , string? errorCode = nameof(AlreadyExistsException), object? parameters = null) : base(message, errorCode, parameters)
    {
    }
}