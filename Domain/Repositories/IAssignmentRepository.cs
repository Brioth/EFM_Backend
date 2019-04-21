using EFM_Backend.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Backend.API.Domain.Repositories
{
    public interface IAssignmentRepository
    {
        Task<IEnumerable<Assignment>> ListAsync();
        Task AddAsync(Assignment assignment);
        Task<Assignment> FindByIdAsync(int id);
        void Update(Assignment assignment);
        void Remove(Assignment assignment);
    }
}
