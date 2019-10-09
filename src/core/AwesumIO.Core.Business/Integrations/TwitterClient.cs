using System;
using System.Threading.Tasks;

using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

using AwesumIO.Core.Common;

namespace AwesumIO.Core.Business.Integrations
{
    public class TwitterClient
    {
        private string _consumerKey = Environment.GetEnvironmentVariable("Twitter_ConsumerKey");
        private string _consumerSecret = Environment.GetEnvironmentVariable("Twitter_ConsumerSecret");
        private string _accessToken = Environment.GetEnvironmentVariable("Twitter_AccessToken");
        private string _accessTokenSecret = Environment.GetEnvironmentVariable("Twitter_AccessTokenSecret");

        public OperationResult SendTweet(string message)
        {
            OperationResult result = new OperationResult();

            try
            {
                Auth.SetUserCredentials(_consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);

                IPublishTweetParameters tweetParams = new PublishTweetParameters(message);
                var tweet = Tweetinvi.Tweet.PublishTweet(tweetParams);
            }
            catch (Exception ex)
            {
                result.FromException(ex);
            }

            return result;
        }
    }
}
