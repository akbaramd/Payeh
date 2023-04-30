using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Payeh.Contracts;

public interface IPayehBuilder : IBuilder<IPayehAppConfigure>
{
    public IServiceCollection Services { get; set; }
    public string Name { get; set; }

    void AddInitializer(Action<IServiceCollection> action);
}