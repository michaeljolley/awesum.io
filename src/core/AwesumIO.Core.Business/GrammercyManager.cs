using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AwesumIO.Core.Common;
using AwesumIO.Core.Data.FaunaDb;

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
    }
}
