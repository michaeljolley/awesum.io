using AwesumIO.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace AwesumIO.Core.Business.Integrations
{
    public interface ITwitterService
    {
        Task<OpResults<ITweet>> GetTweetsAsync();

        OperationResult SendTweet(string recipient, string message);
    }
}
