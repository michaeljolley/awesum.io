using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using AwesumIO.Core.Common;
using AwesumIO.Core.Business;

namespace AwesumIO.Functions
{
    public static class TweetRecorder
    {
        [FunctionName("TweetRecorder")]
        public static async Task Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"TweetRecorder executed at: {DateTime.UtcNow}");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            Tweet tweet = JsonConvert.DeserializeObject<Tweet>(requestBody);

            OperationResult result = new OperationResult();

            GramercyManager grammercyManager = new GramercyManager();
            OpResult<Gramercy> grammercyResult = await grammercyManager.ProcessTweetAsync(tweet);
            result.CopyFrom(grammercyResult);

            log.LogInformation($"TweetRecorder completed at: {DateTime.UtcNow}");
        }
    }
}
