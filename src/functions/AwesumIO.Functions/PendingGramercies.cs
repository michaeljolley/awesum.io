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

using AwesumIO.Functions.Auth;
using AwesumIO.Core.Business;
using AwesumIO.Core.Common;

namespace AwesumIO.Functions
{
    public class PendingGramercies
    {
        private readonly IAccessTokenProvider _tokenProvider;
        private string moderatorRoleName = Environment.GetEnvironmentVariable("moderatorRoleName");

        public PendingGramercies(IAccessTokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
        }

        [FunctionName("PendingGramercies")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"PendingGramercies executed at: {DateTime.UtcNow}");

            var result = await _tokenProvider.ValidateToken(req);

            try
            {
                if (result.Status == AccessTokenStatus.Valid &&
                    result.Principal.IsInRole(moderatorRoleName))
                {
                    GramercyManager gramercyManager = new GramercyManager();

                    OpResults<Gramercy> gramercyResults = await gramercyManager.GetPendingGramerciesAsync();

                    if (gramercyResults.Code != Constants.Enums.OperationResultCode.Success)
                    {
                        log.LogInformation($"PendingGramercies error: {gramercyResults.Message}");
                        return new BadRequestResult();
                    }

                    return new JsonResult(gramercyResults.Results);
                }
                else
                {
                    return new UnauthorizedResult();
                }
            }
            finally
            {
                log.LogInformation($"PendingGramercies completed at: {DateTime.UtcNow}");
            }
        }
    }
}
