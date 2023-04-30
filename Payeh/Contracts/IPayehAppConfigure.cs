using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Payeh.Contracts;

public interface IPayehAppConfigure 
{
    public IApplicationBuilder Application { get; set; }

}