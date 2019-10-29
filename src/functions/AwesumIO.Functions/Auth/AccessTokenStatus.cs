using System;
namespace AwesumIO.Functions.Auth
{
    public enum AccessTokenStatus
    {
        Valid,
        Expired,
        Error,
        NoToken
    }
}
