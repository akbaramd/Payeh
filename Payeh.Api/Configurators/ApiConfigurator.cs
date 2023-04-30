using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Payeh.Api.Contracts;
using Payeh.Contracts;

namespace Payeh.Api.Configurators;

public class ApiConfigurator : IApiConfigurator
{
    private IApplicationBuilder _applicationBuilder;

    public ApiConfigurator(IApplicationBuilder applicationBuilder)
    {
        _applicationBuilder = applicationBuilder;
    }

    public  void Get<Tresponse>(string path)
    {
         _applicationBuilder.UseEndpoints(x =>
        {
            x.MapGet(path,  x => x.Response.WriteAsJsonAsync(""));
        });
    }
}