using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using ServiceBus.Function.App.Contracts;
using ServiceBus.Function.App.Services;

[assembly: FunctionsStartup(typeof(ServiceBus.Function.App.Startup))]
namespace ServiceBus.Function.App
{
    /// <summary>
    /// Function App Startup 
    /// </summary>
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<IMessageService, EmployeeService>();
        }
    }
}
