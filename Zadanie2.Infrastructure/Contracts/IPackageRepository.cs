using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie2.Core;

namespace Zadanie2.Infrastructure
{
    public interface IPackageRepository:IGenericRepository<Package>
    {
        Task<IEnumerable<Package>> GetAll(QueryParameters queryParameters);
        Task<Package> GetPackage(int id);
        Task<Package> UpdatePackageAsync(Package package);
    }
}
