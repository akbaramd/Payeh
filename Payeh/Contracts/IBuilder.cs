namespace Payeh.Contracts;

public interface IBuilder<TBuild>
{
    TBuild Build();
}