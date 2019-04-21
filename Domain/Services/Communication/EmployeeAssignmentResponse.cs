using EFM_Backend.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Backend.API.Domain.Services.Communication
{
    public class EmployeeAssignmentResponse : BaseResponse
    {
        public EmployeeAssignment EmployeeAssignment { get; set; }

        private EmployeeAssignmentResponse(bool success, string message, EmployeeAssignment employeeAssignment) : base(success, message)
        {
            EmployeeAssignment = EmployeeAssignment;
        }

        public EmployeeAssignmentResponse(EmployeeAssignment employeeAssignment) : this(true, string.Empty, employeeAssignment) { }

        public EmployeeAssignmentResponse(string message) : this(false, message, null) { }


    }
}
