using System;

namespace AwesumIO.Core.Common
{
    /// <summary>
    /// Represents a "thank-you" from the sender to recipient
    /// </summary>
    /// <remarks>Grammercy is a synonym for gratitude, recognition, etc.</remarks>
    public class Gramercy
    {
        /// <summary>
        /// Unique identifier of the Grammercy
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Twitter message Id
        /// </summary>
        public long MessageId { get; set; }

        /// <summary>
        /// Message of thanks to the recipient
        /// </summary>
        public string Message { get; set; }
        
        /// <summary>
        /// Twitter handle of the recipient of the thank you
        /// </summary>
        public string RecipientHandle { get; set; }

        /// <summary>
        /// Optional Twitter handle of the person thanking
        /// </summary>
        public string SenderHandle { get; set; }

        /// <summary>
        /// Timestamp of the appreciation message
        /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Has the message been forwarded via Tweet to the recipient
        /// </summary>
        /// <remarks>This is only used when the message was sent anonymously. Meaning there is no SenderHandle.</remarks>
        public bool IsRelayed { get; set; }
    }
}
