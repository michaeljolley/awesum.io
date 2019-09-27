using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using Tweetinvi.Models;

using AwesumIO.Core.Common;
using AwesumIO.Core.Business.Integrations;

namespace AwesumIO.Functions
{
    /// <summary>
    /// Function that runs periodically to gather Tweets with the #awesum hashtag that also
    /// include another users Twitter handle.
    /// </summary>
    public class TwitterWatcher
    {
        private readonly ITwitterService _twitterService;

        public TwitterWatcher(ITwitterService twitterService)
        {
            _twitterService = twitterService;
        }

        [FunctionName("TwitterWatcher")]
        public async Task<List<ITweet>> Run(
            [ActivityTrigger] DateTime startTime,
            ILogger log)
        {
            log.LogInformation($"TwitterWatcher executed at: {DateTime.UtcNow}");

            OpResults<ITweet> newTweetResults = await _twitterService.GetTweetsAsync();

            List<ITweet> tweets = new List<ITweet>();

            if (newTweetResults.Code == Constants.Enums.OperationResultCode.Success)
            {
                tweets = newTweetResults.Results.ToList();
            }
            else
            {
                log.LogError(newTweetResults.Exception, newTweetResults.Message);
            }
            
            log.LogInformation($"TwitterWatcher completed at: {DateTime.UtcNow}");

            return tweets;
        }
    }
}
