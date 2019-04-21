using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Backend.API.Domain.Models
{

    public abstract class EmployeeAssignment
    {

        public int Id { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [Required]
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
    }

    public class EmployeeAssignment_Fixed : EmployeeAssignment
    {
        [Required]
        public double HoursPerOccurence { get; set; }
        [Required]
        public Occurence Occurence { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }

    public class EmployeeAssignment_Variable : EmployeeAssignment
    {
        [Required]
        public double WeeklyFTEPercentage { get; set; }
        public DateTime EndDate { get; set; }
    }
}
