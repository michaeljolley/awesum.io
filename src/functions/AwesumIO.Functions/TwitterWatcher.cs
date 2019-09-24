using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

using AwesumIO.Core.Common;
using AwesumIO.Core.Business;

namespace AwesumIO.Functions
{
    /// <summary>
    /// Function that runs periodically to gather Tweets with the #awesum hashtag that also
    /// include another users Twitter handle.
    /// </summary>
    public static class TwitterWatcher
    {
        [FunctionName("TwitterWatcher")]
        public static void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"TwitterWatcher executed at: {DateTime.UtcNow}");

            TwitterManager twitterManager = new TwitterManager();

            OpResults<string> newTweetResults = twitterManager.GetTweets();

            if (newTweetResults.Code == Constants.Enums.OperationResultCode.Success)
            {
                List<string> newTweets = newTweetResults.Results.ToList();
                foreach (string tweet in newTweets)
                {
                    // Call the TweetProcessor function with this {tweet}

                }
            }

            log.LogInformation($"TwitterWatcher completed at: {DateTime.UtcNow}");
        }
    }
}
