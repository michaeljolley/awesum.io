using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using Tweetinvi.Models;

using AwesumIO.Core.Business;
using AwesumIO.Core.Common;

namespace AwesumIO.Functions
{
    /// <summary>
    /// Receives a tweet message that needs to be processed and loaded to the database.
    /// </summary>
    public static class TweetProcessor
    {
        [FunctionName("TweetProcessor")]
        public static async Task<OperationResult> Run(
            [ActivityTrigger] ITweet tweet,
            ILogger log)
        {
            log.LogInformation($"TweetProcessor executed at: {DateTime.UtcNow}");

            OperationResult result = new OperationResult();

            GramercyManager grammercyManager = new GramercyManager();
            OpResult<Gramercy> grammercyResult = await grammercyManager.ProcessTweetAsync(tweet);
            result.CopyFrom(grammercyResult);

            log.LogInformation($"TweetProcessor completed at: {DateTime.UtcNow}");
            return result;
        }
    }
}
