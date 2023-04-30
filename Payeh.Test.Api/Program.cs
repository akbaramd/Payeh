using Payeh;
using Payeh.Api;
using Payeh.Extensions;
using Payeh.Messaging;
using Payeh.Scheduler;
using Payeh.Test.Api;


WebApplication
    .CreateBuilder(args)
    .Payeh("Test.App")
    .AddJwtAuthentication("test.app.ir", "test.app.ir", "TestApiSecret")
    .Build()
    .UseAuthentication()
    .UseAuthorization()
    .UseRoutingAndEndpoints();