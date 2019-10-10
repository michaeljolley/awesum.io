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
    public static class GramerciesByUser
    {
        [FunctionName("GramerciesByUser")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"GramerciesByUser executed at: {DateTime.UtcNow}");

            string recipientId = req.Query["recipientId"];

            if (string.IsNullOrEmpty(recipientId))
            {
                return new JsonResult(new List<Gramercy>());
            }

            try
            {
                GramercyManager gramercyManager = new GramercyManager();
                OpResults<Gramercy> gramercyResults = await gramercyManager.GetGramerciesByRecipientIdAsync(recipientId);

                if (gramercyResults.Code != Constants.Enums.OperationResultCode.Success)
                {
                    log.LogInformation($"GramerciesByUser error: recipient: {recipientId} | {gramercyResults.Message}");
                }

                return new JsonResult(gramercyResults.Results);
            }
            finally
            {
                log.LogInformation($"GramerciesByUser completed at: {DateTime.UtcNow}");
            }
        }
    }
}
