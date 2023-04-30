using Payeh.Exceptions.Core;

namespace Payeh.Exceptions;

public class NotFoundException : CoreException
{
    public NotFoundException(string message , string? errorCode = nameof(NotFoundException), object? parameters = null) : base(message, errorCode, parameters)
    {
    }
}
