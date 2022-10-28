using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2.Application
{
    public class AddRecipientDTO
    {
        [Required]
        public string Address { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
