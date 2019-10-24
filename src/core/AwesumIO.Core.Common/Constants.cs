using System;

namespace AwesumIO.Core.Common
{
    public static class Constants
    {
        public static class Enums
        {
            /// <summary>
            /// Denotes status of request
            /// </summary>
            public enum OperationResultCode
            {
                /// <summary>
                /// Operation was successful
                /// </summary>
                Success,
                /// <summary>
                /// An error occurred while processing the request
                /// </summary>
                Error,
                /// <summary>
                /// No errors occurred, but the operation was not completely successful
                /// </summary>
                Warning
            }

            /// <summary>
            /// States of the Gramercy
            /// </summary>
            public enum GramercyStatus
            {
                /// <summary>
                /// Gramercy has not been moderated
                /// </summary>
                Pending = 0,
                /// <summary>
                /// Gramercy has been moderated and is being held for further review
                /// </summary>
                Hold = 80,
                /// <summary>
                /// Gramercy is approved for sending & display on the site
                /// </summary>
                Approved = 100,
                /// <summary>
                /// Gramercy was declined
                /// </summary>
                Declined = 199
            }
        }
    }
}
