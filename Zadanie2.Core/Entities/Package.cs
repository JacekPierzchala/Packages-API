using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2.Core
{
    public class Package: BaseEntity
    {
        public string PackageIdentifier { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int RecipientId { get; set; }
        public Recipient Recipient { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
