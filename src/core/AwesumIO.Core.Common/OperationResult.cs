using System;

namespace AwesumIO.Core.Common
{
    /// <summary>
    /// Payload returned by methods
    /// </summary>
    /// <typeparam name="T">Generic object returned by the operation</typeparam>
    public class OperationResult
    {
        public OperationResult()
        {
            Code = Constants.Enums.OperationResultCode.Success;
        }

        #region Properties

        /// <summary>
        /// Code denoting success, failure or warning
        /// </summary>
        public Constants.Enums.OperationResultCode Code { get; set; }

        /// <summary>
        /// Message returned by the operation
        /// </summary>
        public string Message
        {
            get
            {
                if (string.IsNullOrEmpty(_message) && Exception != null)
                {
                    return Exception.Message;
                }
                return _message;
            }
            set
            {
                _message = value;
            }
        }
        private string _message { get; set; }

        /// <summary>
        /// The .NET error stack trace if an error occurred during the operation
        /// </summary>
        public string StackTrace
        {
            get
            {
                return (Exception != null && !string.IsNullOrEmpty(Exception.StackTrace) ? Exception.StackTrace : "");
            }
        }

        /// <summary>
        /// Optional exception that occurred during the operation
        /// </summary>
        public Exception Exception
        {
            get
            {
                return _exception;
            }
            set
            {
                if (value != null)
                {
                    // If the provided exception has an inner exception, we want to traverse to the lowest exception available.
                    while (value.InnerException != null)
                    {
                        value = value.InnerException;
                    };
                }
                _exception = value;
            }
        }
        private Exception _exception { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Copies the IOperationResult properties from one IOperationResult to the current IOperationResult.
        /// </summary>
        /// <param name="opResult">IOperationResult object to copy from.</param>
        public void CopyFrom(OperationResult opResult)
        {
            Code = opResult.Code;
            Message = opResult.Message;
            Exception = opResult.Exception;
        }

        public void FromException(Exception exception)
        {
            _message = null;
            Code = Constants.Enums.OperationResultCode.Error;
            Exception = exception;
        }

        #endregion
    }
}
