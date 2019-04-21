using EFM_Backend.API.Domain.Models;
using EFM_Backend.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Backend.API.Domain.Services
{
    public interface IAssignmentService
    {
        Task<IEnumerable<Assignment>> ListAsync();
        Task<AssignmentResponse> SaveAsync(Assignment assignment);
        Task<AssignmentResponse> UpdateAsync(int id, Assignment assignment);
        Task<AssignmentResponse> DeleteAsync(int id);
    }
}
