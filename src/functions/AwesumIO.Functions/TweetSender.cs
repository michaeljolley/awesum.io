using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

using AwesumIO.Core.Common;
using AwesumIO.Core.Business;

namespace AwesumIO.Functions
{
    public static class TweetSender
    {
        [FunctionName("TweetSender")]
        public static async Task Run([TimerTrigger("0 0 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"TweetSender executed at: {DateTime.UtcNow}");

            try
            {
                GramercyManager gramercyManager = new GramercyManager();
                OperationResult result = await gramercyManager.SendAnonymousGramerciesAsync();

                if (result.Code == Constants.Enums.OperationResultCode.Success)
                {
                    log.LogInformation($"TweetSender result: {result.Code}");
                }
                else
                {
                    log.LogInformation($"TweetSender result: (Error) {result.Message}");
                }
            }
            catch (Exception ex)
            {
                log.LogInformation($"TweetSender error: {ex.Message}");
            }
            finally
            {
                log.LogInformation($"TweetSender completed at: {DateTime.UtcNow}");
            }
        }
    }
}
