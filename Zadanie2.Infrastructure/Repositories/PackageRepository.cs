using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie2.Core;

namespace Zadanie2.Infrastructure
{
    public class PackageRepository : GenericRepository<Package>, IPackageRepository
    {
        public PackageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Package>> GetAll(QueryParameters queryParameters)
        {
            IQueryable<Package> packages = _dbContext.Packages;
            if (!string.IsNullOrEmpty(queryParameters?.Status))
            {
                packages = packages.Where(x => x.Status
                .ToLower() == queryParameters.Status.ToLower());
            }
            if (!string.IsNullOrEmpty(queryParameters?.Recipient))
            {
                packages = packages.Include(c => c.Recipient)
                    .Where(x => x.Recipient.Name
                .ToLower().Contains(queryParameters.Recipient.ToLower()));
            }

            return await packages.ToListAsync();
        }

        public async Task<Package> GetPackage(int id)
        {
            return await _dbContext.Packages.Include(p => p.Recipient)
                .FirstOrDefaultAsync(p=>p.Id==id);
        }

        public async Task<Package> UpdatePackageAsync(Package package)
        {
            var packageFound = await _dbContext.Packages.FindAsync(package.Id);
            if (packageFound != null)
            {
                packageFound.Name = package.Name;
                packageFound.Description = package.Description;
                packageFound.LastUpdated = package.LastUpdated;
            }
            await _dbContext.SaveChangesAsync();
            return packageFound;
        }
    }
}
