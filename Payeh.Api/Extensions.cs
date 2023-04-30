using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Payeh.Api.Configurators;
using Payeh.Api.Contracts;
using Payeh.Contracts;

namespace Payeh.Api;

public static class Extensions
{
    public static IPayehAppConfigure UseRoutingAndEndpoints(this IPayehAppConfigure builder,Action<IApiConfigurator> action = null)
    {
        builder.Application.UseRouting();
        return builder;
    }
}