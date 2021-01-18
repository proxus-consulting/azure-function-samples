using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsSample.DependencyInjection
{
    public class ImportantFunctions
    {
        private readonly HttpClient http;

        public ImportantFunctions(HttpClient http)
        {
            this.http = http;
        }

        [FunctionName("DoImportantWork")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "website")] HttpRequest req, ILogger log)
        {
            log.LogInformation("Doing important work...");

            var url = req.Query["url"];
            log.LogDebug($"GET'ing {url}...");
            var response = await http.GetAsync(url);
            if(response.IsSuccessStatusCode)
                log.LogInformation($"All good, got success status code when querying {url}.");
            else
                log.LogWarning($"Got HTTP response: {response.StatusCode} when querying url: {url}.");

            return new OkResult();
        }
    }
}
