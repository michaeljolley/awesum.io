using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using AwesumIO.Core.Common;
using AwesumIO.Core.Business;

namespace AwesumIO.Functions
{
    public static class Random
    {
        [FunctionName("Random")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            string twitterId = req.Query["twitterId"];

            GramercyManager gramercyManager = new GramercyManager();

            OpResult<Gramercy> result = await gramercyManager.GetRandomGramercyAsync(twitterId);

            return new OkObjectResult(result.Result);
        }
    }
}
