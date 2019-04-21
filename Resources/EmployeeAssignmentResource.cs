using EFM_Backend.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Backend.API.Resources
{
    public abstract class EmployeeAssignmentResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
    }

    public class EmployeeAssignmentResource_Fixed : EmployeeAssignmentResource
    {
        public double HoursPerOccurence { get; set; }
        public Occurence Occurence { get; set; }
    }

    public class EmployeeAssignmentResource_Variable : EmployeeAssignmentResource
    {
        public int ManDays { get; set; }
        public DateTime EndDate { get; set; }
    }
}
