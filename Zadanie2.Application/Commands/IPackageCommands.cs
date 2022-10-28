using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2.Application
{
    public interface IPackageCommands
    {
        Task AddPackageCommand(AddPackageDTO addPackageDTO);
        Task EditPackageCommand(EditPackageDTO editRecipientDTO);
    }
}
