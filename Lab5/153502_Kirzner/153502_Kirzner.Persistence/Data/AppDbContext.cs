using _153502_Kirzner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Kirzner.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<EmployeePosition> EmployeePositions { get; set; }
        public DbSet<JobDuty> JobDuties { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
