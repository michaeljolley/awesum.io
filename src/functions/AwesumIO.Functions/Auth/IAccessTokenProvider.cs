using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AwesumIO.Functions.Auth
{  /// <summary>
   /// Validates access tokes that have been submitted as part of a request.
   /// </summary>
    public interface IAccessTokenProvider
    {
        /// <summary>
        /// Validate the access token, returning the security principal in a result.
        /// </summary>
        /// <param name="request">The HTTP request containing the access token.</param>
        /// <returns>A result that contains the security principal.</returns>
        Task<AccessTokenResult> ValidateToken(HttpRequest request);
    }
}
