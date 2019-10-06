using System;

namespace AwesumIO.Core.Common
{
    public class Tweet
    {
        public string TweetText { get; set; }
        public string TweetId { get; set; }
        public string CreatedAt { get; set; }
        public DateTime CreatedAtISO { get; set; }
        public int RetweetCount { get; set; }
        public string TweetedBy { get; set; }
        public string TweetLanguageCode { get; set; }
        public string TweetInReplyToUserId { get; set; }
        public bool Favorited { get; set; }
        public UserMention[] UserMentions { get; set; }
        public object OriginalTweet { get; set; }
        public UserDetail UserDetails { get; set; }
    }
}
