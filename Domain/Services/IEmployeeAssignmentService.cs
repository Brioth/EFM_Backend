using EFM_Backend.API.Domain.Models;
using EFM_Backend.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Backend.API.Domain.Services
{
    public interface IEmployeeAssignmentService
    {
        Task<IEnumerable<EmployeeAssignment>> ListAsync();
        Task<EmployeeAssignmentResponse> SaveAsync(EmployeeAssignment employeeAssignment);
        Task<EmployeeAssignmentResponse> UpdateAsync(int id, EmployeeAssignment employeeAssignment);
        Task<EmployeeAssignmentResponse> DeleteAsync(int id);
    }
}
