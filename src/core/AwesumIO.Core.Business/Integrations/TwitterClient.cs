using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

using AwesumIO.Core.Common;
using AwesumIO.Core.Data.FaunaDb;

namespace AwesumIO.Core.Business.Integrations
{
    /// <summary>
    /// Manages all interactions with Twitter
    /// </summary>
    public class TwitterClient : ITwitterService
    {
        private string _consumerKey = Environment.GetEnvironmentVariable("Twitter_ConsumerKey");
        private string _consumerSecret = Environment.GetEnvironmentVariable("Twitter_ConsumerSecret");
        private string _accessToken = Environment.GetEnvironmentVariable("Twitter_AccessToken");
        private string _accessTokenSecret = Environment.GetEnvironmentVariable("Twitter_AccessTokenSecret");

        public TwitterClient()
        {
            // Applies credentials for the current thread. If used for the first time, set up the ApplicationCredentials
            Auth.SetUserCredentials(_consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
        }

        // get tweets that include a hashtag
        public async Task<OpResults<ITweet>> GetTweetsAsync()
        {
            OpResults<ITweet> results = new OpResults<ITweet>();

            try
            {
                FaunaContext faunaContext = new FaunaContext();
                OpResult<long> lastSinceResult = await faunaContext.GetLastMessageIdAsync();

                if (lastSinceResult.Code != Constants.Enums.OperationResultCode.Success)
                {
                    results.CopyFrom(lastSinceResult);
                    return results;
                }

                long sinceMessageId = lastSinceResult.Result;

                ISearchTweetsParameters searchParams = new SearchTweetsParameters("#awesum")
                {
                    SinceId = sinceMessageId
                };

                IEnumerable<ITweet> tweets = Search.SearchTweets(searchParams);
                results.Results = tweets;
            }
            catch (Exception ex)
            {
                results.FromException(ex);
            }

            return results;
        }

        /// <summary>
        /// Sends a tweet from the awesumio Twitter account
        /// </summary>
        /// <param name="recipient">Twitter handle of gramercy recipient</param>
        /// <param name="message">Message received for recipient</param>
        /// <returns></returns>
        public OperationResult SendTweet(string recipient, string message)
        {
            OperationResult result = new OperationResult();

            try
            {
                // TODO: Build out what will be the actual tweet message

                // {Random salutation} {recipient}, someone thinks you're #awesum : {message}

                string finalMessage = "";

                IPublishTweetParameters tweetParams = new PublishTweetParameters(finalMessage);
                Tweet.PublishTweet(tweetParams);
            }
            catch (Exception ex)
            {
                result.FromException(ex);
            }

            return result;
        }
    }
}
