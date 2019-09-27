using System;

namespace AwesumIO.Core.Common
{
    public static class EntityFactory
    {
        /// <summary>
        /// Creates a well-formed Gramercy ready for the database
        /// </summary>
        /// <param name="message">Message of thanks to the recipient</param>
        /// <param name="recipientHandle">Twitter handle of the recipient of the thank you</param>
        /// <param name="senderHandle">Optional Twitter handle of the person thanking</param>
        /// <param name="messageId">Twitter message Id</param>
        /// <returns>A well-formed Gramercy</returns>
        public static Gramercy CreateGramercy(string message, string recipientHandle, string senderHandle, long messageId)
        {
            return new Gramercy()
            {
                Id = new Guid().ToString(),
                TimeStamp = DateTime.UtcNow,

                Message = message,
                MessageId = messageId,
                RecipientHandle = recipientHandle,
                SenderHandle = senderHandle
            };
        }

        /// <summary>
        /// Returns a well-formed Ignorable ready for the database
        /// </summary>
        /// <param name="twitterHandle">Twitter handle of user to ignore messages from</param>
        /// <returns>>A well-formed Ignorable</returns>
        public static Ignorable CreateIgnorable(string twitterHandle)
        {
            return new Ignorable()
            {
                TwitterHandle = twitterHandle
            };
        }
    }
}
