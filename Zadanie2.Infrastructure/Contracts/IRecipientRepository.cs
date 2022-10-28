using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie2.Core;

namespace Zadanie2.Infrastructure
{
    public interface IRecipientRepository:IGenericRepository<Recipient>
    {
        Task<Recipient> UpdateRecipientAsync(Recipient recipient);

    }
}
