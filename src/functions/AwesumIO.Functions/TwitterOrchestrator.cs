using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

using Tweetinvi.Models;

using AwesumIO.Core.Common;
using AwesumIO.Core.Business.Integrations;

namespace AwesumIO.Functions
{
    public static class TwitterOrchestrator
    {
        private static int _twitterWatcherErrorThreshold = Convert.ToInt32(Environment.GetEnvironmentVariable("threshold_twitterWatcherError"));

        [FunctionName("TwitterOrchestrator_Start")]
        public static async Task RunAsync(
            [TimerTrigger("0 * * * * *")]TimerInfo myTimer,
            [OrchestrationClient]DurableOrchestrationClient starter,
            ILogger log)
        {
            string instanceId = await starter.StartNewAsync("TwitterOrchestrator", null);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");
        }

        [FunctionName("TwitterOrchestrator")]
        public static async Task RunOrchestrator(
            [OrchestrationTrigger] DurableOrchestrationContext context,
            ILogger log)
        {
            List<ITweet> tweets = await context.CallActivityAsync<List<ITweet>>("TwitterWatcher", DateTime.UtcNow);

            List<Task<OperationResult>> tweetProcessorResults = new List<Task<OperationResult>>();

            foreach (ITweet tweet in tweets)
            {
                Task<OperationResult> processorResult = context.CallActivityAsync<OperationResult>("TweetProcessor", tweet);
                tweetProcessorResults.Add(processorResult);
            }

            await Task.WhenAll(tweetProcessorResults);

            int processingErrors = tweetProcessorResults.Count(c => c.Result.Code != Constants.Enums.OperationResultCode.Success);

            if (processingErrors >= _twitterWatcherErrorThreshold)
            {
                log.LogError($"TwitterOrchestrator: {processingErrors} processing errors exceeded threshold of {_twitterWatcherErrorThreshold}.");
            }
            
            log.LogInformation($"TwitterOrchestrator: Processing completed {tweets.Count - processingErrors} of {tweets.Count} tweets.");
        }
    }
}