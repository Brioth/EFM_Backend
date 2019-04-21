using EFM_Backend.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Backend.API.Domain.Repositories
{
    public interface IEmployeeAssignmentRepository
    {
        Task<IEnumerable<EmployeeAssignment>> ListAsync();
        Task AddAsync(EmployeeAssignment employeeAssignment);
        Task<EmployeeAssignment> FindByIdAsync(int id);
        void Update(EmployeeAssignment employeeAssignment);
        void Remove(EmployeeAssignment employeeAssignment);
    }
}
