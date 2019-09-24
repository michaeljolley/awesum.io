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
        }
    }
}
