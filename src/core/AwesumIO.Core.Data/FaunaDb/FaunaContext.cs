using System;
using System.Threading.Tasks;

using FaunaDB.Client;
using FaunaDB.Types;
using static FaunaDB.Query.Language;

using AwesumIO.Core.Common;

namespace AwesumIO.Core.Data.FaunaDb
{
    public class FaunaContext
    {
        private static string _faunaEndpoint = Environment.GetEnvironmentVariable("faunaEndpoint");
        private static string _faunaSecret = Environment.GetEnvironmentVariable("faunaSecret");

        private readonly FaunaClient _faunaClient = new FaunaClient(endpoint: _faunaEndpoint, secret: _faunaSecret);

        public async Task<OpResult<Gramercy>> SaveGramercyAsync(Gramercy gramercy)
        {
            OpResult<Gramercy> result = new OpResult<Gramercy>();

            try
            {
                await _faunaClient.Query(
                            Create(
                                Ref("grammercy"),
                                Obj("data", Encoder.Encode(gramercy))
                            )
                        );

                result.Result = gramercy;
            }
            catch (Exception ex)
            {
                result.FromException(ex);
            }

            return result;
        }

        public async Task<OpResults<Gramercy>> GetGramerciesByRecipientHandleAsync(string recipientHandle)
        {
            throw new NotImplementedException();
        }

        public async Task<OpResult<long>> GetLastMessageIdAsync()
        {
            throw new NotImplementedException();
        }
    }
}
