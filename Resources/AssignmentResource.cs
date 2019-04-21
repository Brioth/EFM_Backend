using EFM_Backend.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Backend.API.Resources
{
    public abstract class AssignmentResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
    }

    public class AssignmentResource_Fixed : AssignmentResource
    {
        public double HoursPerOccurence { get; set; }
        public Occurence Occurence { get; set; }
    }

    public class AssignmentResource_Variable : AssignmentResource
    {
        public int ManDays { get; set; }
        public DateTime EndDate { get; set; }
    }
}
