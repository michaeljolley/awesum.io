using System;

namespace AwesumIO.Core.Common
{
    /// <summary>
    /// Allows for the merger of types within a solution with an IResult
    /// </summary>
    /// <typeparam name="T">Type used in the ResultBase's Result property</typeparam>
    public class OpResults<T> : OperationResult
    {
        #region Properties

        /// <summary>
        /// The objects affected by the operation
        /// </summary>
        public IEnumerable<T> Results { get; set; }

        #endregion
    }
}
