using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2.Application
{
    public class GetListPackageDTO
    {
        public int Id { get; set; }
        public string PackageIdentifier { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
    }
    public class DetailsPackageDTO:GetListPackageDTO
    {
        public GetRecipientDTO Recipient { get; set; }
        public int RecipientId { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
