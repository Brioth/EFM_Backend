using EFM_Backend.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Backend.API.Domain.Services.Communication
{
    public class EmployeeResponse : BaseResponse
    {
        public Employee Employee { get; set; }

        private EmployeeResponse(bool success, string message, Employee employee) : base(success, message)
        {
            Employee = employee;
        }

        public EmployeeResponse(Employee employee) : this(true, string.Empty, employee) { }

        public EmployeeResponse(string message) : this(false, message, null) { }


    }
}
