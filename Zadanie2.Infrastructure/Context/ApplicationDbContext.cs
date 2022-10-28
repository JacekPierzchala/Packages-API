using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie2.Core;

namespace Zadanie2.Infrastructure
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>opt):base(opt)
        {}
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<Package> Packages { get; set; }
    }
}
