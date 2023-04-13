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
    public class EmployeePositionService : IEmployeePositionService
    {
        private IUnitOfWork _unitOfWork;

        public EmployeePositionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task AddAsync(EmployeePosition item)
        {
            return _unitOfWork.EmployeePositionRepository.AddAsync(item);
        }

        public Task DeleteAsync(int id)
        {
            EmployeePosition employeePosition = GetByIdAsync(id).Result;
            return _unitOfWork.EmployeePositionRepository.DeleteAsync(employeePosition);
        }

        public Task<IReadOnlyList<EmployeePosition>> GetAllAsync()
        {
            return _unitOfWork.EmployeePositionRepository.ListAllAsync();
        }

        public Task<EmployeePosition> GetByIdAsync(int id)
        {
            return _unitOfWork.EmployeePositionRepository.GetByIdAsync(id);
        }

        public Task UpdateAsync(EmployeePosition item)
        {
            return _unitOfWork.EmployeePositionRepository.UpdateAsync(item);
        }
    }
}
