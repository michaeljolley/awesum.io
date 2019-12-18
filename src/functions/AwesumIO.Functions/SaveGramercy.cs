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
    public class SaveGramercy
    {
        private readonly IAccessTokenProvider _tokenProvider;
        private string moderatorRoleName = Environment.GetEnvironmentVariable("moderatorRoleName");

        public SaveGramercy(IAccessTokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
        }

        [FunctionName("SaveGramercy")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"SaveGramercy executed at: {DateTime.UtcNow}");

            var result = await _tokenProvider.ValidateToken(req);

            try
            {
                if (result.Status == AccessTokenStatus.Valid &&
                    result.Principal.IsInRole(moderatorRoleName))
                {
                    string grammercyId = req.Query["gramercyId"];
                    string reqStatus = req.Query["status"];

                    if (string.IsNullOrEmpty(grammercyId) || !int.TryParse(reqStatus, out int status))
                    {
                        return new BadRequestResult();
                    }


                    GramercyManager gramercyManager = new GramercyManager();

                    OpResult<Gramercy> gramercyResults = await gramercyManager.UpdateGrammercy(grammercyId, status);

                    if (gramercyResults.Code != Constants.Enums.OperationResultCode.Success)
                    {
                        log.LogInformation($"SaveGramercy error: {gramercyResults.Message}");
                        return new BadRequestResult();
                    }

                    return new JsonResult(gramercyResults.Result);
                }
                else
                {
                    return new UnauthorizedResult();
                }
            }
            finally
            {
                log.LogInformation($"SaveGramercy completed at: {DateTime.UtcNow}");
            }
        }
    }
}
