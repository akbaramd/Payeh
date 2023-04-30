using System.Security.Claims;

namespace Payeh.Services.Contracts;

public interface IJwtService
{
   string Generate(string userId, List<Claim>? claims);
}