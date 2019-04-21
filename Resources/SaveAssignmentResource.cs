using EFM_Backend.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Backend.API.Resources
{
    public abstract class SaveAssignmentResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
    }

    public class SaveAssignmentResource_Fixed : SaveAssignmentResource
    {
        public double HoursPerOccurence { get; set; }
        public Occurence Occurence { get; set; }
    }

    public class SaveAssignmentResource_Variable : SaveAssignmentResource
    {
        public int ManDays { get; set; }
        public DateTime EndDate { get; set; }
    }
}
