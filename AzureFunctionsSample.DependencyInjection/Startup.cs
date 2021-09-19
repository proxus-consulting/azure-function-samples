using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(AzureFunctionsSample.DependencyInjection.Startup))]

namespace AzureFunctionsSample.DependencyInjection
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            // This is needed for our services that requires a simple HttpClient
            builder.Services.AddHttpClient();

            //// This is registering a preconfigured HttpClient for our WeatherFunctions
            //builder.Services.AddHttpClient<WeatherService>(client =>
            //{
            //    client.BaseAddress = new Uri("https://www.metaweather.com/api/");
            //});
        }
    }
}