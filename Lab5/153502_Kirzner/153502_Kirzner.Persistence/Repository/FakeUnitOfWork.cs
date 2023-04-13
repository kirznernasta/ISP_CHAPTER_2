using _153502_Kirzner.Domain.Abstractions;
using _153502_Kirzner.Domain.Entities;
using _153502_Kirzner.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Kirzner.Persistence.Repository
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private readonly Lazy<IRepository<EmployeePosition>> _employeePositionRepository;
        private readonly Lazy<IRepository<JobDuty>> _jobDutyRepository;

        public FakeUnitOfWork()
        {
            _employeePositionRepository = new Lazy<IRepository<EmployeePosition>>(() => new FakeEmployeePositionRepository());
            _jobDutyRepository = new Lazy<IRepository<JobDuty>>(() => new FakeJobDutyRepository());
        }

        public IRepository<EmployeePosition> EmployeePositionRepository => _employeePositionRepository.Value;

        public IRepository<JobDuty> JobDutyRepository => _jobDutyRepository.Value;
        public async Task CreateDatabaseAsync()
        {
        }
        public async Task RemoveDatbaseAsync()
        {
        }
        public async Task SaveAllAsync()
        {
           
        }

    }
}
