using _153502_Kirzner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Kirzner.ApplicationServices.Abstractions
{
    public interface IJobDutyService : IBaseService<JobDuty>
    {
        Task<IReadOnlyList<JobDuty>> GetAllByImployeePositionIdAsync(int id);
    }
}
