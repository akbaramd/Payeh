using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Payeh.Builders;
using Payeh.Contracts;
using Payeh.Extensions;

namespace Payeh;

public static class Extension
{
    public static IPayehBuilder Payeh(this WebApplicationBuilder appBuilder ,string name)
    {
        var payehBuilder = new PayehBuilder(name, appBuilder);
        
        return payehBuilder;
    }
    
}