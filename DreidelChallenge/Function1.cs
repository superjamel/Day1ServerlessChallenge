using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DreidelChallenge
{
    public static class Function1
    {
        [FunctionName("Dreidel")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string[] dreidel = new string[4] { "נ", "ג", "ה", "ש" };

            Random rnd = new Random();
            int randomValue = rnd.Next(4);

            return (ActionResult)new OkObjectResult(dreidel[randomValue]);
        }
    }
}
