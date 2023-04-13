using _153502_Kirzner.ApplicationServices.Abstractions;
using _153502_Kirzner.Domain.Abstractions;
using _153502_Kirzner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Kirzner.ApplicationServices.Services
{
    public class JobDutyService : IJobDutyService
    {
        private IUnitOfWork _unitOfWork;
        public JobDutyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task AddAsync(JobDuty item)
        {
            return _unitOfWork.JobDutyRepository.AddAsync(item);
        }

        public Task DeleteAsync(int id)
        {
            return _unitOfWork.JobDutyRepository.DeleteAsync(GetByIdAsync(id).Result);
        }

        public Task<IReadOnlyList<JobDuty>> GetAllAsync()
        {
            return _unitOfWork.JobDutyRepository.ListAllAsync();
        }

        public Task<IReadOnlyList<JobDuty>> GetAllByImployeePositionIdAsync(int id)
        {
            return _unitOfWork.JobDutyRepository.ListAsync((duty) => duty.EmployeePositionId == id);
        }

        public Task<JobDuty> GetByIdAsync(int id)
        {
            return _unitOfWork.JobDutyRepository.GetByIdAsync(id);
        }

        public Task UpdateAsync(JobDuty item)
        {
            return _unitOfWork.JobDutyRepository.UpdateAsync(item);
        }
    }
}
