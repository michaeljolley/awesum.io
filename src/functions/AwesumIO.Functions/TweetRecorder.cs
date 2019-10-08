using System;
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
    public static class TweetRecorder
    {
        [FunctionName("TweetRecorder")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"TweetRecorder executed at: {DateTime.UtcNow}");

            IActionResult result = new OkResult();

            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                Tweet tweet = JsonConvert.DeserializeObject<Tweet>(requestBody);

                if (string.IsNullOrEmpty(tweet.Message))
                {
                    log.LogInformation($"TweetRecorder error: Message not provided.");
                    return new BadRequestObjectResult("Message is required.");
                }

                if (tweet.Message.Length > 228)
                {
                    log.LogInformation($"TweetRecorder error: Message provided was {tweet.Message.Length} characters.");
                    return new BadRequestObjectResult("Message must be less than 229 characters.");
                }

                if (tweet.UserMentions.Length == 0)
                {
                    log.LogInformation($"TweetRecorder error: No recipients specified.");
                    return new BadRequestObjectResult("Recipient is required.");
                }

                GramercyManager grammercyManager = new GramercyManager();
                OpResult<Gramercy> grammercyResult = await grammercyManager.ProcessTweetAsync(tweet);
                log.LogInformation($"TweetRecorder result: {grammercyResult.Code}");
            }
            catch (Exception ex)
            {
                result = new BadRequestObjectResult(new { message = ex.Message });
                log.LogInformation($"TweetRecorder error: {ex.Message}");
            }
            finally
            {
                log.LogInformation($"TweetRecorder completed at: {DateTime.UtcNow}");
            }

            return result;
        }
    }
}
