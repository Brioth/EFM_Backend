using EFM_Backend.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Backend.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Assignment_Fixed> Fixed_Assignments { get; set; }
        public DbSet<Assignment_Variable> Variable_Assignments { get; set; }
        public DbSet<EmployeeAssignment> EmployeeAssignments { get; set; }
        public DbSet<EmployeeAssignment_Fixed> Fixed_EmployeeAssignments { get; set; }
        public DbSet<EmployeeAssignment_Variable> Variable_EmployeeAssignments { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<EmployeeAssignment>()
                .HasIndex(ea => new { ea.EmployeeId, ea.AssignmentId }).IsUnique();

        }
    }
}
