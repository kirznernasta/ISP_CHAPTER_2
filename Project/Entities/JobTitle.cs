using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities
{
    [Table("Jobs")]
    public class JobTitle
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Sphere { get; set; }

        public JobTitle(string title, string sphere)
        {
            Title = title;
            Sphere = sphere;
        }

        public JobTitle() 
        {
            Title = string.Empty;
        }

        public override string ToString()
        { 
            return Title;
        }
    }

}
