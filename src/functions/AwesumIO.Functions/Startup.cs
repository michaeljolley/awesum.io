using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using AwesumIO.Functions.Auth;
using Microsoft.IdentityModel.Logging;

[assembly: FunctionsStartup(typeof(AwesumIO.Functions.Startup))]
namespace AwesumIO.Functions
{
    /// <summary>
    /// Runs when the Azure Functions host starts.
    /// </summary>
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            IdentityModelEventSource.ShowPII = true;

            // Get the configuration files for the OAuth token issuer
            var issuerToken = Environment.GetEnvironmentVariable("IssuerToken");
            var audience = Environment.GetEnvironmentVariable("Audience");
            var issuer = Environment.GetEnvironmentVariable("Issuer");

            // Register the access token provider as a singleton
            builder.Services.AddSingleton<IAccessTokenProvider, AccessTokenProvider>(s => new AccessTokenProvider(issuerToken, audience, issuer));
        }
    }
}
