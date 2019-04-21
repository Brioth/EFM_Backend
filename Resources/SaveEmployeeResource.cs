using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Backend.API.Resources
{
    public class SaveEmployeeResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
