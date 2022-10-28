﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2.Application
{
    public class AddPackageDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public int RecipientId { get; set; }
 
    }
}
