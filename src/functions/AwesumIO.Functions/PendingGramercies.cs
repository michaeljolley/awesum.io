using System;
using System.Collections.Generic;
using System.IO;
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
    public static class PendingGramercies
    {
        [FunctionName("PendingGramercies")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"PendingGramercies executed at: {DateTime.UtcNow}");

            //string recipientId = req.Query["recipientId"];

            //if (string.IsNullOrEmpty(recipientId))
            //{
            //    return new JsonResult(new List<Gramercy>());
            //}

            try
            {
                GramercyManager gramercyManager = new GramercyManager();
                OpResults<Gramercy> gramercyResults = await gramercyManager.GetPendingGramerciesAsync();

                if (gramercyResults.Code != Constants.Enums.OperationResultCode.Success)
                {
                    log.LogInformation($"PendingGramercies error: {gramercyResults.Message}");
                }

                return new JsonResult(gramercyResults.Results);
            }
            finally
            {
                log.LogInformation($"PendingGramercies completed at: {DateTime.UtcNow}");
            }
        }
    }
}
