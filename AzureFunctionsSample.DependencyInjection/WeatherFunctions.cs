using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsSample.DependencyInjection
{
    public class WeatherFunctions
    {
        private readonly WeatherService weather;

        public WeatherFunctions(WeatherService weather)
        {
            this.weather = weather;
        }

        [FunctionName("CheckWeather")]
        public async Task Run([TimerTrigger("0 */5 * * * *", RunOnStartup = true)]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"Checking weather for Copenhagen...");
            await weather.CheckWeather();
        }
    }
}
