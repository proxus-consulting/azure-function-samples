using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AzureFunctionsSample.DependencyInjection.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFunctionsSample.DependencyInjection
{
    public class WeatherService
    {
        private readonly HttpClient http;
        private readonly ILogger<WeatherService> log;

        public WeatherService(HttpClient http, ILogger<WeatherService> log)
        {
            this.http = http;
            this.log = log;
        }

        public async Task CheckWeather()
        {
            var weather = JsonConvert.DeserializeObject<WeatherResponse>(await http.GetStringAsync("location/554890/"));
            var todaysWeather =
                weather.consolidated_weather.FirstOrDefault(x =>
                    x.applicable_date == $"{DateTime.UtcNow.ToShortDateString()}");

            if(todaysWeather == null)
                log.LogWarning("Unable to get weather for today!");
            else
            {
                // Warn if nasty weather today
                if (todaysWeather.weather_state_abbr == "sn" ||
                    todaysWeather.weather_state_abbr == "t" ||
                    todaysWeather.weather_state_abbr == "hr")
                {
                    // TODO: Send alert...
                    log.LogInformation("Today's weather might require an umbrella!");
                }
            }
        }
    }
}
