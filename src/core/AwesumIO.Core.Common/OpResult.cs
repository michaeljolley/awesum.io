using System;

namespace AwesumIO.Core.Common
{
    /// <summary>
    /// Allows for the merger of types within a solution with an IResult
    /// </summary>
    /// <typeparam name="T">Type used in the ResultBase's Result property</typeparam>
    public class OpResult<T> : OperationResult
    {
        #region Properties

        /// <summary>
        /// The object affected by the operation
        /// </summary>
        public T Result { get; set; }

        #endregion
    }
}
