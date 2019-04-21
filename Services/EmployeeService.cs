using EFM_Backend.API.Domain.Models;
using EFM_Backend.API.Domain.Repositories;
using EFM_Backend.API.Domain.Services;
using EFM_Backend.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Backend.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeAssignmentRepository _employeeAssignmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeAssignmentRepository employeeAssignmentRepository,IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _employeeAssignmentRepository = employeeAssignmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Employee>> ListAsync()
        {
            return await _employeeRepository.ListAsync();
        }

        public async Task<EmployeeResponse> GetByIdAsync(int id)
        {
            var existingEmployee = await _employeeRepository.FindByIdAsync(id);

            if (existingEmployee == null)
                return new EmployeeResponse("Employee not found.");

            return new EmployeeResponse(existingEmployee);
        }

        public async Task<EmployeeResponse> SaveAsync(Employee employee)
        {
            try
            {
                foreach (var assignment in employee.EmployeeAssignments)
                {
                    var existingAssignment = await _employeeAssignmentRepository.FindByIdAsync(assignment.Id);
                    if(existingAssignment == null)
                    {
                        return new EmployeeResponse("Invalid EmployeeAssignment");
                    }
                }        

                await _employeeRepository.AddAsync(employee);
                await _unitOfWork.CompleteAsync();

                return new EmployeeResponse(employee);
            }
            catch (Exception ex)
            {
                return new EmployeeResponse($"An error occurred when saving the employee: {ex.Message}");
            }
        }

        public async Task<EmployeeResponse> UpdateAsync(int id, Employee employee)
        {
            var existingEmployee = await _employeeRepository.FindByIdAsync(id);

            if (existingEmployee == null)
                return new EmployeeResponse("Employee not found.");

            foreach (var assignment in employee.EmployeeAssignments)
            {
                var existingAssignment = await _employeeAssignmentRepository.FindByIdAsync(assignment.Id);
                if (existingAssignment == null)
                {
                    return new EmployeeResponse("Invalid EmployeeAssignment");
                }
            }

            existingEmployee.Name = employee.Name;

            try
            {
                _employeeRepository.Update(existingEmployee);
                await _unitOfWork.CompleteAsync();

                return new EmployeeResponse(existingEmployee);
            }
            catch(Exception ex)
            {
                return new EmployeeResponse($"An error occurred when updating the category: {ex.Message}");
            }
        }

        public async Task<EmployeeResponse> DeleteAsync(int id)
        {
            var existingEmployee = await _employeeRepository.FindByIdAsync(id);

            if (existingEmployee == null)
                return new EmployeeResponse("Employee not found.");

            try
            {
                _employeeRepository.Remove(existingEmployee);
                await _unitOfWork.CompleteAsync();

                return new EmployeeResponse(existingEmployee);
            }
            catch (Exception ex)
            {
                return new EmployeeResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }
    }
}
