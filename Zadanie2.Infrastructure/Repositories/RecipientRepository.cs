using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie2.Core;

namespace Zadanie2.Infrastructure
{
    public class RecipientRepository : GenericRepository<Recipient>, IRecipientRepository
    {
        public RecipientRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Recipient> UpdateRecipientAsync(Recipient recipient)
        {
            var recipientFound = await _dbContext.Recipients.FindAsync(recipient.Id);
            if(recipientFound!=null)
            {
                recipientFound.Name=recipient.Name;
                recipientFound.Address=recipient.Address;
            }
            await _dbContext.SaveChangesAsync();    
            return recipientFound;
        }
    }
}
