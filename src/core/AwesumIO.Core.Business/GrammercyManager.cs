using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AwesumIO.Core.Common;
using AwesumIO.Core.Business.Integrations;
using AwesumIO.Core.Data.FaunaDb;
using FaunaDB.Types;

namespace AwesumIO.Core.Business
{
    public class GramercyManager
    {
        public async Task<OpResult<Gramercy>> ProcessTweetAsync(Tweet tweet)
        {
            OpResult<Gramercy> result = new OpResult<Gramercy>();

            try
            {
                if (tweet.UserMentions.Count() > 0)
                {
                    IEnumerable<string> recipients = tweet.UserMentions.Select(s => s.UserName);

                    FaunaContext faunaContext = new FaunaContext();

                    foreach (string recipient in recipients)
                    {
                        Gramercy gramercy = EntityFactory.CreateGramercy(tweet.Message, recipient, tweet.SenderHandle, tweet.MessageId);
                        result = await faunaContext.SaveGramercyAsync(gramercy);
                    }
                }
            }
            catch (Exception ex)
            {
                result.FromException(ex);
            }

            return result;
        }

        public async Task<OperationResult> SendAnonymousGramerciesAsync()
        {
            OperationResult result = new OperationResult();

            try
            {
                // Use the FaunaDbContext to get all non-sent gramercies with:
                // 1. isRelayed = false
                // 2. senderHandle = null

                FaunaContext faunaContext = new FaunaContext();
                OpResults<Value> unsentGramercyResults = await faunaContext.GetUnsentGramerciesAsync();

                if (unsentGramercyResults.Code != Constants.Enums.OperationResultCode.Success)
                {
                    result.CopyFrom(unsentGramercyResults);
                    return result;
                }

                int unsentGramercies = unsentGramercyResults.Results.Count();

                if (unsentGramercies > 0)
                {
                    TwitterClient twitterClient = new TwitterClient();

                    // For each gramercy, send a tweet and record isRelayed = true
                    foreach (Value gramercyValue in unsentGramercyResults.Results)
                    {
                        Gramercy gramercy = gramercyValue.ToGramercy();

                        string message = $"Hey @{gramercy.RecipientHandle}, someone thinks you're #awesum! {gramercy.Message}";
                        OperationResult sendResult = twitterClient.SendTweet(message);

                        if (sendResult.Code == Constants.Enums.OperationResultCode.Success)
                        {
                            gramercy.IsRelayed = true;
                            await faunaContext.SaveGramercyAsync(gramercy, gramercyValue, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.FromException(ex);
            }

            return result;
        }
    }
}
