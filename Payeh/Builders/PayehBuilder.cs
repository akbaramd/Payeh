using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Payeh.Configurations;
using Payeh.Contracts;

namespace Payeh.Builders;

public class PayehBuilder : IPayehBuilder
{
    private readonly WebApplicationBuilder _builder;
    public PayehBuilder(string name,WebApplicationBuilder builder)
    {
        Name = name;
        Services = builder.Services;
        _builder = builder;
    }

    public string Name { get; set; }
    public IServiceCollection Services { get; set; }
    
    private readonly List<Action<IServiceCollection>> _actions = new List<Action<IServiceCollection>>();  


    public void AddInitializer(Action<IServiceCollection> action)
    {
        _actions.Add(action);
    }
    
    public IPayehAppConfigure Build()
    {
        
        foreach (var action in _actions)
        {
            action.Invoke(Services);
        }

        var app = _builder.Build();
        return new PayehAppConfigure(app);
    }
}