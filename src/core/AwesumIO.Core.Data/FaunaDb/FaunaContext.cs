using System;
using System.Threading.Tasks;

using AwesumIO.Core.Common;

namespace AwesumIO.Core.Data.FaunaDb
{
    public class FaunaContext
    {
        public async Task<OpResult<Gramercy>> SaveGramercyAsync(Gramercy gramercy)
        {
            throw new NotImplementedException();
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
