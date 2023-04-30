namespace Payeh.Api.Contracts;

public interface IApiConfigurator
{
    void Get<Tresponse>(string path);
}