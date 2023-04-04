using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Kirzner.Domain.Entities
{
    public class EmployeePosition : Entity
    {
        public double Salary { get; set; }
        public List<JobDuty> JobDuties { get; set; }
    }
}
