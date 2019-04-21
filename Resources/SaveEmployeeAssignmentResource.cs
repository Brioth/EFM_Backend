using EFM_Backend.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Backend.API.Resources
{
    public abstract class SaveEmployeeAssignmentResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
    }

    public class SaveEmployeeAssignmentResource_Fixed : SaveEmployeeAssignmentResource
    {
        public double HoursPerOccurence { get; set; }
        public Occurence Occurence { get; set; }
    }

    public class SaveEmployeeAssignmentResource_Variable : SaveEmployeeAssignmentResource
    {
        public int ManDays { get; set; }
        public DateTime EndDate { get; set; }
    }
}
