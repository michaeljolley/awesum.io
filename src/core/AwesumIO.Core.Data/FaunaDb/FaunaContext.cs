using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<OpResult<Gramercy>> SaveGramercyAsync(Gramercy gramercy, Value gramercyValue = null, bool isUpdate = false)
        {
            OpResult<Gramercy> result = new OpResult<Gramercy>();

            try
            {
                if (isUpdate)
                {
                    await _faunaClient.Query(
                                Update(
                                    gramercyValue.At("ref"),
                                    Obj("data", Encoder.Encode(gramercy))
                                )
                            );
                }
                else
                {
                    await _faunaClient.Query(
                                Create(
                                    Ref("classes/gramercy"),
                                    Obj("data", Encoder.Encode(gramercy))
                                )
                            );
                }

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

        public async Task<OpResults<Value>> GetUnsentGramerciesAsync()
        {
            OpResults<Value> results = new OpResults<Value>();

            try
            {
                Value result = await _faunaClient.Query(
                                         Map(
                                             Paginate(
                                                 Match(
                                                     Index("unsent_gramercy"),
                                                     "",
                                                     false,
                                                     true
                                                 )
                                             ),
                                             Lambda(
                                                 "gramercy",
                                                 Get(
                                                     Var("gramercy")
                                                 )
                                             )
                                         )
                                     );

                Value[] data = result.At("data").To<Value[]>().Value;
                results.Results = data.ToList();
            }
            catch (Exception ex)
            {
                results.FromException(ex);
            }

            return results;
        }
    }
}
