using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie2.Infrastructure;

namespace Zadanie2.Application
{
    public interface IPackageQueries
    {
        Task<IEnumerable<GetListPackageDTO>> GetPackages(QueryParameters queryParameters);
        Task<DetailsPackageDTO> GetPackage(int id);
        Task<string> GetBarcodePackageById(int id);
        Task<bool> Exists(int id);
    }
}
