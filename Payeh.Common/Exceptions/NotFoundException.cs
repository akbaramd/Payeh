using Payeh.Common.Exceptions.Core;

namespace Payeh.Common.Exceptions;

public class NotFoundException : CoreException
{
    public NotFoundException(string message , string? errorCode = nameof(NotFoundException), object? parameters = null) : base(message, errorCode, parameters)
    {
    }
}
