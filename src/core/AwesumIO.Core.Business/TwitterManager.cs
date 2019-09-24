using System;

using Tweetinvi;
using Tweetinvi.Parameters;

using AwesumIO.Core.Common;
using System.Collections.Generic;
using Tweetinvi.Models;

namespace AwesumIO.Core.Business
{
    /// <summary>
    /// Manages all interactions with Twitter
    /// </summary>
    public class TwitterManager
    {
        private void Authenticate()
        {
            // TODO: Authenticate the app with Twitter API
        }

        // get tweets that include a hashtag
        public OpResults<string> GetTweets()
        {
            OpResults<string> results = new OpResults<string>();

            try
            {
                ISearchTweetsParameters searchParams = new SearchTweetsParameters("#awesum")
                {
                    SinceId = 0
                };

                Authenticate();

                IEnumerable<ITweet> tweets = Search.SearchTweets(searchParams);

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

                Authenticate();

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
