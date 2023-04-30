using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Payeh.Contracts;

namespace Payeh.Configurations;

public class PayehAppConfigure : IPayehAppConfigure
{
    public PayehAppConfigure(IApplicationBuilder application)
    {
        Application = application;
    }

    public IApplicationBuilder Application { get; set; }
}