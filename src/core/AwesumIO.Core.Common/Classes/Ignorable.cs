using System;

namespace AwesumIO.Core.Common
{
    /// <summary>
    /// Record denoting users that we should ignore messages from.
    /// </summary>
    public class Ignorable
    {
        /// <summary>
        /// Twitter handle of the user we will ignore
        /// </summary>
        public string TwitterHandle { get; set; }
    }
}
