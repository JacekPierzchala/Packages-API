using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2.Application
{
    public interface IRecipientQueries
    {
        Task<bool> Exists(int id);
    }
}
