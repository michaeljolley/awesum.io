using System;

using FaunaDB.Types;

namespace AwesumIO.Core.Common
{
    /// <summary>
    /// Represents a "thank-you" from the sender to recipient
    /// </summary>
    /// <remarks>Grammercy is a synonym for gratitude, recognition, etc.</remarks>
    public class Gramercy
    {
        public Gramercy() { }

        [FaunaConstructor]
        public Gramercy(string id, string messageId, string message, string recipientHandle, string senderHandle, DateTime timestamp, bool isRelayed)
        {
            Id = id;
            MessageId = messageId;
            Message = message;
            RecipientHandle = recipientHandle;
            SenderHandle = senderHandle;
            TimeStamp = timestamp;
            IsRelayed = isRelayed;
        }

        /// <summary>
        /// Unique identifier of the Grammercy
        /// </summary>
        [FaunaField("id")]
        public string Id { get; set; }

        /// <summary>
        /// Twitter message Id
        /// </summary>
        [FaunaField("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// Message of thanks to the recipient
        /// </summary>
        [FaunaField("message")]
        public string Message { get; set; }

        /// <summary>
        /// Twitter handle of the recipient of the thank you
        /// </summary>
        [FaunaField("recipientHandle")]
        public string RecipientHandle { get; set; }

        /// <summary>
        /// Optional Twitter handle of the person thanking
        /// </summary>
        [FaunaField("senderHandle")]
        public string SenderHandle { get; set; }

        /// <summary>
        /// Timestamp of the appreciation message
        /// </summary>
        [FaunaField("timeStamp")]
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Has the message been forwarded via Tweet to the recipient
        /// </summary>
        /// <remarks>This is only used when the message was sent anonymously. Meaning there is no SenderHandle.</remarks>
        [FaunaField("isRelayed")] 
        public bool IsRelayed { get; set; }
    }

    public static class Extensions
    {
        public static Gramercy ToGramercy(this Value value)
        {
            return Decoder.Decode<Gramercy>(value.At("data"));
        }
    }
}
