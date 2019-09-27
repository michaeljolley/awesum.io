using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Tweetinvi.Models;

using AwesumIO.Core.Common;
using AwesumIO.Core.Data.FaunaDb;
using System.Linq;

namespace AwesumIO.Core.Business
{
    public class GramercyManager
    {
        public async Task<OpResult<Gramercy>> ProcessTweetAsync(ITweet tweet)
        {
            OpResult<Gramercy> result = new OpResult<Gramercy>();

            try
            {
                if (tweet.UserMentions.Count > 0)
                {
                    IEnumerable<string> recipients = tweet.UserMentions.Select(s => s.ScreenName);

                    FaunaContext faunaContext = new FaunaContext();

                    foreach (string recipient in recipients)
                    {
                        Gramercy gramercy = EntityFactory.CreateGramercy(tweet.FullText, recipient, tweet.CreatedBy.ScreenName, tweet.Id);
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
    }
}
