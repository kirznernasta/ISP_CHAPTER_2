using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static Android.Graphics.ImageDecoder;

namespace Project.Services
{
    public interface IDbService
    {
        IEnumerable<JobTitle> GetAllJobTitles();
        IEnumerable<Duty> GetJobDuties(int id);
        void Init();
    }
}
