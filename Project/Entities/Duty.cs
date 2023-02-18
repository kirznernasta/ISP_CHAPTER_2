//using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities
{
    [Table("Duties")]
    public class Duty
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int DutyId { get; set; } 

        public string DutyTitle { get; set; }

        [Indexed]
        public int JobId { get; set; }  

        public Duty(string dutyTitle, int jobId)
        {
            DutyTitle = dutyTitle;
            JobId = jobId;
        }

        public Duty() 
        {
            DutyTitle= string.Empty;
        }

        public override string ToString()
        {
            return DutyTitle;
        }
    }   
}
