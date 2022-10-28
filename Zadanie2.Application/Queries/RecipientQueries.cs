using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie2.Infrastructure;

namespace Zadanie2.Application
{
    public class RecipientQueries : IRecipientQueries
    {
        private readonly IRecipientRepository _recipientRepository;

        public RecipientQueries(IRecipientRepository recipientRepository)
        {
            _recipientRepository = recipientRepository;
        }
        public async Task<bool> Exists(int id)
        {
            return await _recipientRepository.Exists(id);
        }
    }
}
