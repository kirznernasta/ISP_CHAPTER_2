using _153502_Kirzner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Kirzner.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<EmployeePosition> EmployeePositionRepository { get; }
        IRepository<JobDuty> JobDutyRepository { get; }
        public Task RemoveDatbaseAsync();
        public Task CreateDatabaseAsync();
        public Task SaveAllAsync();
    }
}
