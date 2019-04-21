using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Backend.API.Domain.Models
{
    public enum Occurence : byte
    {
        [Description("D")]
        Daily = 1,

        [Description("W")]
        Weekly = 2,

        [Description("M")]
        Monthly = 3
    }

    public abstract class Assignment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        public IList<EmployeeAssignment> EmployeeAssignments { get; set; } = new List<EmployeeAssignment>();

    }

    public class Assignment_Fixed : Assignment
    {
        [Required]
        public double HoursPerOccurence { get; set; }
        [Required]
        public Occurence Occurence { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }

    public class Assignment_Variable : Assignment
    {
        [Required]
        public int ManDays { get; set; }
    }
}
